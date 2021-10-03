using Microsoft.Extensions.Logging;
using Product.Core.Services.Interfaces;
using Product.Infrastructure.Entities;
using Product.Infrastructure.Repositories.Interfaces;
using Product.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Core.Services
{
    public class PlantService : IPlantService
    {
        private readonly IPlantRepository _plantRepository;
        private readonly ILogger<PlantService> _logger;


        public PlantService(
            IPlantRepository plantRepository,
            ILogger<PlantService> logger)
        {
            _logger = logger;
            _plantRepository = plantRepository;
        }

        public async Task<Plant> AddPlantAsync(Plant newPlant)
        {
            if (newPlant is null || newPlant.Id != 0)
            {
                return null;
            }

            try
            {
                return await _plantRepository.AddPlantAsync(newPlant);
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(PlantService),
                    nameof(AddPlantAsync),
                    $"Failed to add new plant",
                    ex);

                return null;
            }
        }

        public async Task<bool> DeleteAsync(int plantId)
        {
            try
            {
                return await _plantRepository.DeleteAsync(plantId);
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(PlantService),
                    nameof(DeleteAsync),
                    $"Failed delete plant id={plantId}",
                    ex);

                return false;
            }

        }

        public async Task<List<Plant>> GetAllAsync()
        {
            try
            {
                return await _plantRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(PlantService),
                    nameof(GetAllAsync),
                    $"Cannot get data from database",
                    ex);

                return null;
            }
        }

        public async Task<List<Plant>> GetFavPlants()
        {
            try
            {
                return await _plantRepository.GetFavPlants();
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(PlantService),
                    nameof(GetFavPlants),
                    $"Cannot get data from database",
                    ex);

                return null;
            }
        }

        public async Task<Plant> GetPlantByIdAsync(int plantId)
        {
            try
            {
                return await _plantRepository.GetPlantByIdAsync(plantId);
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(PlantService),
                    nameof(GetPlantByIdAsync),
                    $"Cannot get plant from database plant id={plantId}",
                    ex);

                return null;
            }
        }

        public async Task<Plant> UpdateAsync(Plant plant)
        {
            if (plant is null)
            {
                return null;
            }

            try
            {
                return await _plantRepository.UpdateAsync(plant);
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(PlantService),
                    nameof(UpdateAsync),
                    $"Failed updating plant id={plant.Id}",
                    ex);

                return null;
            }

        }

        public async Task<List<Plant>> GetAllPalantInCategory(int categoryId)
        {
            try
            {
                return await _plantRepository.GetAllPalantInCategory(categoryId);
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(PlantService),
                    nameof(GetAllPalantInCategory),
                    $"Cannot get plants from database ",
                    ex);

                return null;
            }

        }

        public async Task<List<Plant>> Search(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            try
            {
                return await _plantRepository.Search(name);
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(PlantService),
                    nameof(Search),
                    $"Cannot get plants from database",
                    ex);

                return null;
            }
        }
    }
}
