using Product.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetAllASync();

        Task<Category> AddCategoryAsync(Category newCategory);

        Task<Category> UpdateAsync(Category category);

        Task<bool> DeleteAsync(int categoryId);


    }
}
