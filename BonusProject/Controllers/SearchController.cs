using BonusProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace BonusProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTableNames(string shart)
        {
            var res = Serarch.GetTableNames(shart);

            return Ok(res);
        }
    }
}
