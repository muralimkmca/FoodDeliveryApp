using FoodyApi.Data;
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
        public async Task<IActionResult> GetFoods()
        {
            var foodlist = await _foodDbContext.FoodInfos.ToListAsync();
            return Ok(foodlist);
        }


        [HttpPost]
        public string InsertWeather(string Foodname)
        {
            return string.Format("Your selection is {0}", Foodname);
        }
    }
}
