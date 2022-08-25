using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace FoodDeliveryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodAdminController : ControllerBase
    {

        [HttpGet]
        public ArrayList ListofFoods()
        {
            ArrayList Foods = new ArrayList();
            Foods.Add("Roti");
            Foods.Add("Dosa");
            Foods.Add("Biriyani");

            return Foods;
        }
    }
}
