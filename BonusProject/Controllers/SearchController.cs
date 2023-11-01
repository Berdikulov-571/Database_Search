using BonusProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace BonusProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        [HttpGet]
        public IActionResult FromOneDatabase(string shart)
        {
            var res = Serarch.FromOneDatabase(shart);

            return Ok(res);
        }

        [HttpGet]
        public IActionResult FromAllDatabase(string shart)
        {
            var res = Serarch.FromAllDatabase(shart);
            return Ok(res);
        }
    }
}
