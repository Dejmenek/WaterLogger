using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using WaterLogger.Dejmenek.Models;

namespace WaterLogger.Dejmenek.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public CreateModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DrinkingWaterModel DrinkingWater { get; set; } = default!;

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (var connection = new SqliteConnection(_configuration.GetConnectionString("WaterLogger")))
            {
                connection.Open();
                string sql = @"INSERT INTO drinking_water (Quantity, Date)
                               VALUES (@Quantity, @Date)
                ";

                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@Quantity", DrinkingWater.Quantity);
                command.Parameters.AddWithValue("@Date", DrinkingWater.Date);

                command.ExecuteNonQuery();
            }

            return RedirectToPage("./Index");
        }
    }
}
