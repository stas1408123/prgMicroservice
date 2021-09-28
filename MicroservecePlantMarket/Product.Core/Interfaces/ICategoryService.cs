using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Infrastructure.Entities;

namespace Product.Core.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllASync();

        Task<Category> AddCategoryAsync(Category newCategory);

        Task<Category> UpdateAsync(Category category);

        Task<bool> DeleteAsync(int categoryId);


    }
}
