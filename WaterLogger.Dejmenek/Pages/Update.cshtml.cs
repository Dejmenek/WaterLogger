using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterLogger.Dejmenek.Models;
using WaterLogger.Dejmenek.Repositories;

namespace WaterLogger.Dejmenek.Pages
{
    public class UpdateModel : PageModel
    {
        private readonly IDrinkingWaterRepository _drinkingWaterRepository;
        private readonly ILogger _logger;
        [BindProperty]
        public DrinkingWaterModel DrinkingWater { get; set; } = default!;

        public UpdateModel(IDrinkingWaterRepository drinkingWaterRepository, ILogger logger)
        {
            _drinkingWaterRepository = drinkingWaterRepository;
            _logger = logger;
        }

        public IActionResult OnGet(int id)
        {
            try
            {
                DrinkingWater = _drinkingWaterRepository.GetById(id);
                _logger.LogInformation("Successfully retrieved drinking water record with Id: {Id}.", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the drinking water record with Id: {Id}.", id);
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _drinkingWaterRepository.Update(DrinkingWater);
                _logger.LogInformation("Successfully updated drinking water record with Id: {Id}.", DrinkingWater.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the drinking water record with Id: {Id}.", DrinkingWater.Id);
            }

            return RedirectToPage("./Index");
        }
    }
}
