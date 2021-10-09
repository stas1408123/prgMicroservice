using Product.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.BLL.Services.Interfaces
{
    public interface IPlantService
    {
        Task<IEnumerable<Plant>> GetAllAsync();

        Task<Plant> GetPlantByIdAsync(int plantId);

        Task<IEnumerable<Plant>> GetFavPlants();

        Task<Plant> AddPlantAsync(Plant newPlant);

        Task<Plant> UpdateAsync(Plant plant);

        Task<bool> DeleteAsync(int plantId);

        Task<IEnumerable<Plant>> GetAllPalantInCategory(int categoryId);

        Task<IEnumerable<Plant>> Search(string name);
    }
}
