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
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly ProductContext _productContext;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(
            ProductContext productContext,
            ILogger<CategoryRepository> logger)
        {
            _productContext = productContext;
            _logger = logger;
        }

        public async Task<Category> AddCategoryAsync(Category newCategory)
        {
            try
            {
                await _productContext.Categories.AddAsync(newCategory);

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
            try
            {
                var exCategory = await _productContext.Categories
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

        public async Task<ICollection<Category>> GetAllASync()
        {
            try
            {
                var categories = await _productContext.Categories
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
            try
            {
                if (!_productContext.Categories.Any(p => p.Id == category.Id))
                {
                    return null;
                }

                _productContext.Entry(category).State = EntityState.Modified;

                await _productContext.SaveChangesAsync();

                var exCategory = await _productContext.Categories
                    .FirstOrDefaultAsync(item => item.Id == category.Id);

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
