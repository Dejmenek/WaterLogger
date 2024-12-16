using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterLogger.Dejmenek.Models;
using WaterLogger.Dejmenek.Repositories;

namespace WaterLogger.Dejmenek.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IDrinkingWaterRepository _drinkingWaterRepository;

        public CreateModel(IDrinkingWaterRepository drinkingWaterRepository)
        {
            _drinkingWaterRepository = drinkingWaterRepository;
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
            }
            catch (Exception ex)
            {

            }

            return RedirectToPage("./Index");
        }
    }
}
