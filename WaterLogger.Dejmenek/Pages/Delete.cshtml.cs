using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using WaterLogger.Dejmenek.Models;

namespace WaterLogger.Dejmenek.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IConfiguration _configuration;
        [BindProperty]
        public DrinkingWaterModel DrinkingWater { get; set; }
        public DeleteModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult OnGet(int id)
        {
            DrinkingWater = GetById(id);

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            using (var connection = new SqliteConnection(_configuration.GetConnectionString("WaterLogger")))
            {
                connection.Open();
                string sql = "DELETE FROM drinking_water WHERE Id = @Id";

                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }

                return RedirectToPage("./Index");
            }
        }

        private DrinkingWaterModel GetById(int id)
        {
            var drinkingWaterRecord = new DrinkingWaterModel();

            using (var connection = new SqliteConnection(_configuration.GetConnectionString("WaterLogger")))
            {
                connection.Open();
                string sql = "SELECT * FROM drinking_water WHERE Id = @Id";
                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    drinkingWaterRecord.Id = reader.GetInt32(0);
                    drinkingWaterRecord.Quantity = reader.GetDouble(1);
                    drinkingWaterRecord.Date = DateTime.Parse(reader.GetString(2));
                }
            }

            return drinkingWaterRecord;
        }
    }
}
