using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Infrastructure.Entities;

namespace Product.Infrastructure.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllASync();

        Task<Category> AddCategoryAsync(Category newCategory);

        Task<Category> UpdateAsync(Category category);

        Task<bool> DeleteAsync(int categoryId);


    }
}
