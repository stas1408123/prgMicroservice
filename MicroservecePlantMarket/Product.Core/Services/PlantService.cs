using Product.BLL.Services.Interfaces;
using Product.DAL.Entities;
using Product.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.BLL.Services
{
    internal class PlantService : IPlantService
    {
        private readonly IPlantRepository _plantRepository;

        public PlantService(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository ?? throw new ArgumentNullException(nameof(plantRepository));
        }

        public async Task<Plant> AddPlantAsync(Plant newPlant)
        {
            return await _plantRepository.AddPlantAsync(newPlant);
        }

        public async Task<bool> DeleteAsync(int plantId)
        {
            return await _plantRepository.DeleteAsync(plantId);
        }

        public async Task<IEnumerable<Plant>> GetAllAsync()
        {
            return await _plantRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Plant>> GetFavPlants()
        {
            return await _plantRepository.GetFavPlants();
        }

        public async Task<Plant> GetPlantByIdAsync(int plantId)
        {
            return await _plantRepository.GetPlantByIdAsync(plantId);
        }

        public async Task<Plant> UpdateAsync(Plant plant)
        {
            return await _plantRepository.UpdateAsync(plant);
        }

        public async Task<IEnumerable<Plant>> GetAllPalantInCategory(int categoryId)
        {
            return await _plantRepository.GetAllPalantInCategory(categoryId);
        }

        public async Task<IEnumerable<Plant>> Search(string name)
        {
            return await _plantRepository.Search(name);
        }
    }
}
