using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Infrastructure.Entities;

namespace Product.Infrastructure.Repositories.Interfaces
{
    public interface IPlantRepository
    {
        Task<List<Entities.Plant>> GetAllAsync();

        Task<Entities.Plant> GetPlantByIdAsync(int plantId);

        Task<List<Entities.Plant>> GetFavPlants();

        Task<Entities.Plant> AddPlantAsync(Entities.Plant newPlant);

        Task<Entities.Plant> UpdateAsync(Entities.Plant plant);

        Task<bool> DeleteAsync(int plantId);

        Task<List<Entities.Plant>> GetAllPalantInCategory(int categoryId);

        Task<List<Entities.Plant>> Search(string name);
    }
}
