using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Product.Infrastructure.Entities;
using Product.Core.Services.Interfaces;

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
            _categoryService = categoryService;
        }


        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllASync();
            
            if(categories == null)
            {
                return BadRequest();
            }

            return Ok(categories);
        }

        [HttpDelete]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var isDelete = await _categoryService.DeleteAsync(id);

            if(isDelete== false)
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

            if(category == null)
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

            if(category == null)
            {
                return BadRequest();
            }

            return Ok(newCategory);

        }

        
    }

    
}
