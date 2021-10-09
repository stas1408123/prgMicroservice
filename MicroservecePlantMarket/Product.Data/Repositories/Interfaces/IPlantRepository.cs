using Product.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.DAL.Repositories.Interfaces
{
    public interface IPlantRepository
    {
        Task<ICollection<Plant>> GetAllAsync();

        Task<Plant> GetPlantByIdAsync(int plantId);

        Task<ICollection<Plant>> GetFavPlants();

        Task<Plant> AddPlantAsync(Plant newPlant);

        Task<Plant> UpdateAsync(Plant plant);

        Task<bool> DeleteAsync(int plantId);

        Task<ICollection<Plant>> GetAllPalantInCategory(int categoryId);

        Task<ICollection<Plant>> Search(string name);
    }
}
