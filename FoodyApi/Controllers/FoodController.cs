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

        //[HttpGet]
        //public ArrayList ListofFoods()
        //{
        //    ArrayList Foods = new ArrayList();
        //    Foods.Add("Roti");
        //    Foods.Add("Dosa");
        //    Foods.Add("Biriyani");

        //    return Foods;
        //}

        [HttpGet]
        public IActionResult GetFoods()
        {
            var foodlist = _foodDbContext.FoodInfos.ToList();
            return Ok(foodlist);
        }

        [HttpPost]
        public IActionResult InsertFoodInfo([FromBody]FoodInfo foods)
        {
            _foodDbContext.FoodInfos.Add(foods);
            _foodDbContext.SaveChanges();

            return Ok(foods);            
        }

        //[HttpPost]
        //public string InsertWeather(string Foodname)
        //{
        //    return string.Format("Your selection is {0}", Foodname);
        //}
    }
}
