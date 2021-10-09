using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Product.DAL.Context;
using Product.DAL.Entities;
using Product.DAL.Repositories.Interfaces;
using Product.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.DAL.Repositories.Implementations
{
    internal class PlantRepository : IPlantRepository
    {
        private readonly ProductContext _productContext;
        private readonly ILogger<PlantRepository> _logger;

        public PlantRepository(
            ProductContext productContext,
            ILogger<PlantRepository> logger)
        {
            _logger = logger;
            _productContext = productContext;
        }

        public async Task<Plant> AddPlantAsync(Plant newPlant)
        {
            try
            {
                await _productContext.Plants.AddAsync(newPlant);

                await _productContext.SaveChangesAsync();

                return newPlant;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(PlantRepository),
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
                if (!_productContext.Plants.Any(plant => plant.Id == plantId))
                {
                    return false;
                }

                var exProduct = await _productContext.Plants
                        .FirstOrDefaultAsync(item => item.Id == plantId);

                _productContext.Plants.Remove(exProduct);

                await _productContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(PlantRepository),
                    nameof(DeleteAsync),
                    $"Failed delete plant id={plantId}",
                    ex);

                return false;
            }

        }

        public async Task<ICollection<Plant>> GetAllAsync()
        {
            try
            {
                var plants = await _productContext.Plants
                        .Include(item => item.Category)
                        .Where(item => item.IsAvailable == true)
                        .ToListAsync();

                return plants;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(PlantRepository),
                    nameof(GetAllAsync),
                    $"Cannot get data from database",
                    ex);

                return null;
            }
        }

        public async Task<ICollection<Plant>> GetFavPlants()
        {
            try
            {
                var plants = await _productContext.Plants
                        .Include(item => item.Category)
                        .Where(item => item.IsFavourite == true)
                        .ToListAsync();

                return plants;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(PlantRepository),
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
                if (!_productContext.Plants.Any(p => p.Id == plantId))
                {
                    return null;
                }

                return await _productContext.Plants
                        .FirstOrDefaultAsync(item => item.Id == plantId);
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(PlantRepository),
                    nameof(GetPlantByIdAsync),
                    $"Cannot get plant from database plant id={plantId}",
                    ex);

                return null;
            }
        }

        public async Task<Plant> UpdateAsync(Plant plant)
        {
            try
            {
                if (!_productContext.Plants.Any(p => p.Id == plant.Id))
                {
                    return null;
                }

                _productContext.Entry(plant).State = EntityState.Modified;

                await _productContext.SaveChangesAsync();

                return plant;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(PlantRepository),
                    nameof(UpdateAsync),
                    $"Failed updating plant id={plant.Id}",
                    ex);

                return null;
            }

        }

        public async Task<ICollection<Plant>> GetAllPalantInCategory(int categoryId)
        {
            try
            {
                var plants = _productContext.Plants
                    .Include(item => item.Category)
                    .Where(item => item.Category.Id == categoryId);

                return await plants.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(PlantRepository),
                    nameof(GetAllPalantInCategory),
                    $"Cannot get plants from database ",
                    ex);

                return null;
            }
        }

        public async Task<ICollection<Plant>> Search(string name)
        {
            try
            {
                var plants = _productContext.Plants
                    .Include(category => category.Category)
                    .Where(plant => plant.Name == name);

                return await plants.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(PlantRepository),
                    nameof(Search),
                    $"Cannot get plants from database",
                    ex);

                return null;
            }
        }
    }
}
