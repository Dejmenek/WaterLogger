using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterLogger.Dejmenek.Models;
using WaterLogger.Dejmenek.Repositories;

namespace WaterLogger.Dejmenek.Pages;
public class IndexModel : PageModel
{
    private readonly IDrinkingWaterRepository _drinkingWaterRepository;
    public List<DrinkingWaterModel> Records { get; set; } = new List<DrinkingWaterModel>();

    public IndexModel(IDrinkingWaterRepository drinkingWaterRepository)
    {
        _drinkingWaterRepository = drinkingWaterRepository;
    }

    public IActionResult OnGet()
    {
        try
        {
            Records = _drinkingWaterRepository.GetAllRecords();
        }
        catch (Exception ex) { }

        return Page();
    }
}
