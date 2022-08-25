using FoodieApi.Model;
using FoodieApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodieController : ControllerBase
    {
        private readonly FoodServices _foodservices;
        public FoodieController(FoodServices foodServices)
        {
            this._foodservices = foodServices;
        }

        [HttpGet]
        public async Task<List<Foods>> Get()
        {
           return await _foodservices.GettheFood();
        }

        [HttpPost]
        public async Task<OkObjectResult> Insert(Foods foods)
        {
            await _foodservices.InsertFoodDetails(foods);
            return Ok(foods);
        }
    }
}
