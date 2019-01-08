using Microsoft.AspNetCore.Mvc;

namespace SWFU.CMS.API.Controllers
{
    [Route("api/values")]
    public class ValueController:Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello");

        }
    }
}