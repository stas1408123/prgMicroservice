using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Product.Infrastructure.Context;
using Product.Infrastructure.Entities;
using Product.Infrastructure.Repositories.Interfaces;
using Product.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repositories.Implementations
{
    public class PlantRepository : IPlantRepository
    {
        private readonly ProductContext _productContext;
        private readonly ILogger<PlantRepository> _logger;


        public PlantRepository(ProductContext productContext,
            ILogger<PlantRepository> logger)
        {
            _logger = logger;
            _productContext = productContext;
        }

        public async Task<Plant> AddPlantAsync(Plant newPlant)
        {
            if(newPlant== null || newPlant.Id!=0)
            {
                return null;
            }
            try
            {

                await _productContext.Plants
                   .AddAsync(newPlant);

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

                _productContext.Plants
                    .Remove(exProduct);

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

        public async Task<List<Plant>> GetAllAsync()
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

        public async Task<List<Plant>> GetFavPlants()
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
            if(plant is null)
            {
                return null;
            }

            try
            {
                var exPlant = await _productContext.Plants
                        .FirstOrDefaultAsync(item => item.Id == plant.Id);

                if (!(exPlant is null))
                {
                    exPlant.Name = plant.Name;
                    exPlant.ShortDescription = plant.ShortDescription;
                    exPlant.LongDescription = plant.LongDescription;
                    exPlant.Price = plant.Price;
                    exPlant.IsFavourite = plant.IsFavourite;
                    exPlant.IsAvailable = plant.IsAvailable;
                    exPlant.CategoryId = plant.CategoryId;
                    exPlant.PictureLink = plant.PictureLink;
                }

                await _productContext.SaveChangesAsync();

                return exPlant;
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

        public async Task<List<Plant>> GetAllPalantInCategory(int categoryId)
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

        public async Task<List<Plant>> Search(string name)
        {
            if(string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

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
