using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Product.Infrastructure.Repositories.Interfaces;
using Product.Infrastructure.Context;
using Product.Infrastructure.Entities;
using Product.Shared;

namespace Product.Infrastructure.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductContext _productContext;
        private readonly ILogger<CategoryRepository> _logger;
        public CategoryRepository(ProductContext productContext,
            ILogger<CategoryRepository> logger)
        {
            _productContext = productContext;
            _logger = logger;
        }

        public async Task<Category> AddCategoryAsync(Category newCategory)
        {
            if(newCategory is null)
            {
                return null;
            }

            try
            {
                await _productContext.AddAsync<Category>(newCategory);
                await _productContext.SaveChangesAsync();
                return newCategory;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(CategoryRepository),
                    nameof(AddCategoryAsync),
                    $"Failed to add new category",
                    ex);

                return null;
            }

        }

        public async Task<bool> DeleteAsync(int categoryId)
        {
            if (categoryId == 0)
            {
                return false;
            }

            try
            {
                var exCategory = await _productContext.Categories
                    .Include(item => item.Plants)
                    .FirstOrDefaultAsync(i => i.Id == categoryId);

                _productContext.Categories
                    .Remove(exCategory);

                await _productContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(CategoryRepository),
                    nameof(DeleteAsync),
                    $"Failed delete category",
                    ex);

                return false;
            }

        }

        public async Task<List<Category>> GetAllASync()
        {
            try
            {

                var categories = await _productContext.Categories
                    .Include(item => item.Plants)
                    .ToListAsync();

                return categories;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(CategoryRepository),
                    nameof(GetAllASync),
                    $"Cannot get data from database",
                    ex);

                return null;
            }


        }



        public async Task<Category> UpdateAsync(Category category)
        {
            if(category == null)
            {
                return null;
            }

            try
            {
                var exCategory = await _productContext.Categories
                    .Include(item => item.Plants)
                    .FirstOrDefaultAsync(item => item.Id == category.Id);

                exCategory.Name = category.Name;
                exCategory.Description = category.Description;


                if (exCategory.Plants.Count != 0)
                {
                    _productContext.Plants
                        .RemoveRange(exCategory.Plants);
                }

                exCategory.Plants.AddRange(category.Plants);

                await _productContext.SaveChangesAsync();

                return exCategory;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(CategoryRepository),
                    nameof(UpdateAsync),
                    $"Failed updating category id={category.Id}",
                    ex);

                return null;
            }

        }

        
        
    }
}
