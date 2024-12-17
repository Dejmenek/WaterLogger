using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterLogger.Dejmenek.Models;
using WaterLogger.Dejmenek.Repositories;

namespace WaterLogger.Dejmenek.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IDrinkingWaterRepository _drinkingWaterRepository;
        private readonly ILogger _logger;

        public CreateModel(IDrinkingWaterRepository drinkingWaterRepository, ILogger logger)
        {
            _drinkingWaterRepository = drinkingWaterRepository;
            _logger = logger;
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

            try
            {
                _drinkingWaterRepository.Create(DrinkingWater);
                _logger.LogInformation("Successfully created drinking water record with Id: {Id}.", DrinkingWater.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the drinking water record.");
            }

            return RedirectToPage("./Index");
        }
    }
}
