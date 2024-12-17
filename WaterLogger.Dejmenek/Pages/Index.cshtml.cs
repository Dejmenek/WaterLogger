using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterLogger.Dejmenek.Models;
using WaterLogger.Dejmenek.Repositories;

namespace WaterLogger.Dejmenek.Pages;
public class IndexModel : PageModel
{
    private readonly IDrinkingWaterRepository _drinkingWaterRepository;
    private readonly ILogger _logger;
    public List<DrinkingWaterModel> Records { get; set; } = new List<DrinkingWaterModel>();

    public IndexModel(IDrinkingWaterRepository drinkingWaterRepository, ILogger logger)
    {
        _drinkingWaterRepository = drinkingWaterRepository;
        _logger = logger;
    }

    public IActionResult OnGet()
    {
        try
        {
            Records = _drinkingWaterRepository.GetAllRecords();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving drinking water records.");
        }

        return Page();
    }
}
