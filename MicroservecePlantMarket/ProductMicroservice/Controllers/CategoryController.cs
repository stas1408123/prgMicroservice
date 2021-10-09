using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.BLL.Services.Interfaces;
using Product.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductMicroservice.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [HttpGet]
        [Route("GetAllCategories")]
        [AllowAnonymous]
        public async Task<IEnumerable<Category>> GetAllCategories()
        {

            return await _categoryService.GetAllAsync();

        }

        [HttpDelete]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var isDelete = await _categoryService.DeleteAsync(id);

            if (isDelete == false)
            {
                return BadRequest();
            }

            return Ok(isDelete);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> AddNewCategory([FromBody] Category newCategory)
        {
            var category = await _categoryService
                .AddCategoryAsync(newCategory);

            if (category == null)
            {
                return BadRequest();
            }

            return Ok(category);
        }

        [HttpPut]
        public async Task<ActionResult<Category>> UpdateCategory([FromBody] Category newCategory)
        {
            var category = await _categoryService
                .UpdateAsync(newCategory);

            if (category == null)
            {
                return BadRequest();
            }

            return Ok(newCategory);
        }
    }
}
