using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.BLL.Services.Interfaces;
using Product.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : Controller
    {
        private readonly IPlantService _plantService;

        public PlantController(IPlantService plantService)
        {
            _plantService = plantService;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Plant>>> GetAllProducts()
        {
            var products = await _plantService
                .GetAllAsync();

            if (products is null)
            {
                return BadRequest();
            }

            return Ok(products);
        }

        [HttpGet]
        [Route("GetFavPlants")]
        [AllowAnonymous]
        public async Task<ActionResult<Plant>> GetFavPlants()
        {
            var products = await _plantService
                .GetFavPlants();

            if (products is null)
            {
                return BadRequest();
            }

            return Ok(products);
        }

        [HttpGet]
        [Route("GetPlant")]
        [AllowAnonymous]
        public async Task<ActionResult<Plant>> GetPlantById(int id)
        {
            var plant = await _plantService
                .GetPlantByIdAsync(id);

            if (plant == null)
            {
                return BadRequest();
            }

            return Ok(plant);
        }

        [HttpPost]
        [Route("AddPlant")]
        public async Task<ActionResult<Plant>> AddPlant([FromBody] Plant newPlant)
        {
            var plant = await _plantService
                .AddPlantAsync(newPlant);

            if (plant == null)
            {
                return BadRequest();
            }

            return Ok(plant);
        }

        [HttpPut]
        public async Task<ActionResult<Plant>> UpdatePlant([FromBody] Plant newPlant)
        {
            var plant = await _plantService
                .UpdateAsync(newPlant);

            if (plant == null)
            {
                return BadRequest(0);
            }

            return Ok(plant);
        }


        [HttpDelete]
        public async Task<ActionResult<bool>> DeletePlant(int id)
        {
            var plant = await _plantService
                .DeleteAsync(id);

            if (plant == false)
            {
                return BadRequest();
            }

            return Ok(plant);

        }

        [HttpGet]
        [Route("GetAllPalantInCategory")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Plant>>> GetPlantInCategory(int categoryId)
        {

            var plants = await _plantService
                .GetAllPalantInCategory(categoryId);

            if (plants == null)
            {
                return BadRequest();
            }

            return Ok(plants.ToList());
        }

        [HttpGet]
        [Route("Search")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Plant>>> Search(string name)
        {
            var plant = await _plantService
                .Search(name);

            return Ok(plant);
        }

    }
}
