using FoodyApi.Data;
using FoodyApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace FoodyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly FoodDbContext _foodDbContext;

        public FoodController(FoodDbContext foodDbContext)
        {
            this._foodDbContext = foodDbContext;
        }       

        //Retrieve
        [HttpGet]
        public IActionResult GetFoods()
        {
            var foodlist = _foodDbContext.FoodInfos.ToList();
            return Ok(foodlist);
        }


        //Insert
        [HttpPost]
        public IActionResult InsertFoodInfo([FromBody] FoodInfo foods)
        {
            _foodDbContext.FoodInfos.Add(foods);
            _foodDbContext.SaveChanges();

            return Ok(foods);
        }


        //Update
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateFoodInfo(int id, [FromBody] FoodInfo foods)
        {
            var existingItem = _foodDbContext.FoodInfos.FirstOrDefault(x => x.Id == id);
            if (existingItem != null)
            {
                existingItem.FoodName = foods.FoodName;
                existingItem.FoodDescription = foods.FoodDescription;
                existingItem.Available = foods.Available;
                existingItem.Quantity = foods.Quantity;

                _foodDbContext.SaveChanges();
                return Ok(existingItem);
            }
            return NotFound("Item not found");
        }

        //Delete
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteFoodmenu(int id)
        {
            var existingItem = _foodDbContext.FoodInfos.FirstOrDefault(x => x.Id == id);
            if (existingItem != null)
            {
                _foodDbContext.Remove(existingItem);
                _foodDbContext.SaveChanges();
                return Ok(existingItem);
            }
            return NotFound("Item not found to delete");
        }
    }
}