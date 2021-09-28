using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Product.Infrastructure.Repositories.Interfaces;
using Product.Infrastructure.Entities;
using Product.Shared;
using Product.Core.Services.Interfaces;

namespace Product.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _logger;
        public CategoryService(ICategoryRepository categoryRepository,
            ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
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
                await _categoryRepository.AddCategoryAsync(newCategory);
                return newCategory;
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(CategoryService),
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
                return await _categoryRepository.DeleteAsync(categoryId);

            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(CategoryService),
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

                return await _categoryRepository.GetAllASync();
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(CategoryService),
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
                return await _categoryRepository.UpdateAsync(category);
            }
            catch (Exception ex)
            {
                _logger.LogErrorByTemplate(
                    nameof(CategoryService),
                    nameof(UpdateAsync),
                    $"Failed updating category id={category.Id}",
                    ex);

                return null;
            }

        }

        
        
    }
}
