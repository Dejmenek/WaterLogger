using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using WaterLogger.Dejmenek.Models;

namespace WaterLogger.Dejmenek.Pages;
public class IndexModel : PageModel
{
    private readonly IConfiguration _configuration;
    public List<DrinkingWaterModel> Records { get; set; } = new List<DrinkingWaterModel>();

    public IndexModel(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IActionResult OnGet()
    {
        Records = GetAllRecords();

        return Page();
    }

    private List<DrinkingWaterModel> GetAllRecords()
    {
        var data = new List<DrinkingWaterModel>();
        using (var connection = new SqliteConnection(_configuration.GetConnectionString("WaterLogger")))
        {
            connection.Open();
            string sql = "SELECT * FROM drinking_water";
            using var command = new SqliteCommand(sql, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                data.Add(new DrinkingWaterModel
                {
                    Id = reader.GetInt32(0),
                    Quantity = reader.GetDouble(1),
                    Date = DateTime.Parse(reader.GetString(2))
                });
            }
        }

        return data;
    }
}
