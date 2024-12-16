using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterLogger.Dejmenek.Models;
using WaterLogger.Dejmenek.Repositories;

namespace WaterLogger.Dejmenek.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IDrinkingWaterRepository _drinkingWaterRepository;
        [BindProperty]
        public DrinkingWaterModel DrinkingWater { get; set; } = default!;

        public DeleteModel(IDrinkingWaterRepository drinkingWaterRepository)
        {
            _drinkingWaterRepository = drinkingWaterRepository;
        }

        public IActionResult OnGet(int id)
        {
            try
            {
                DrinkingWater = _drinkingWaterRepository.GetById(id);
            }
            catch (Exception ex) { }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            try
            {
                _drinkingWaterRepository.Delete(id);
            }
            catch (Exception ex)
            {
            }
            return RedirectToPage("./Index");
        }
    }
}
