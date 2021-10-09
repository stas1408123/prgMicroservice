using Product.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category> AddCategoryAsync(Category newCategory);

        Task<Category> UpdateAsync(Category category);

        Task<bool> DeleteAsync(int categoryId);
    }
}
