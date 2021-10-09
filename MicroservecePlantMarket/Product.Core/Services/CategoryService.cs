using Product.BLL.Services.Interfaces;
using Product.DAL.Entities;
using Product.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.BLL.Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<Category> AddCategoryAsync(Category newCategory)
        {
            return await _categoryRepository.AddCategoryAsync(newCategory);
        }

        public async Task<bool> DeleteAsync(int categoryId)
        {
            return await _categoryRepository.DeleteAsync(categoryId);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllASync();
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            return await _categoryRepository.UpdateAsync(category);
        }
    }
}
