using WaterLogger.Dejmenek.Models;

namespace WaterLogger.Dejmenek.Repositories;

public interface IDrinkingWaterRepository
{
    DrinkingWaterModel GetById(int id);
    void Create(DrinkingWaterModel drinkingWater);
    void Update(DrinkingWaterModel drinkingWater);
    void Delete(int id);
    List<DrinkingWaterModel> GetAllRecords();
}
