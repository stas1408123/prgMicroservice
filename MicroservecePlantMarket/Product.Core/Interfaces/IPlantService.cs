using Product.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Core.Services.Interfaces
{
    public interface IPlantService
    {
        Task<List<Plant>> GetAllAsync();

        Task<Plant> GetPlantByIdAsync(int plantId);

        Task<List<Plant>> GetFavPlants();

        Task<Plant> AddPlantAsync(Plant newPlant);

        Task<Plant> UpdateAsync(Plant plant);

        Task<bool> DeleteAsync(int plantId);

        Task<List<Plant>> GetAllPalantInCategory(int categoryId);

        Task<List<Plant>> Search(string name);
    }
}
