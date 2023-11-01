using BonusProject.Models;
using BonusProject.Services;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

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

        [HttpGet]
        public IActionResult GetUserById(int Id)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudyCenterDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DynamicParameters parametres = new DynamicParameters();
                parametres.Add("userId", Id);

                User? user = connection.QueryFirstOrDefault<User>("GetUserById", parametres, commandType: CommandType.StoredProcedure);

                return Ok(user);
            }
        }

        [HttpGet]
        public IActionResult GetWithTwoParametr(int first,int two)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudyCenterDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                User? user = connection.QueryFirstOrDefault<User>($"exec GetUsersWithYear {first},{two}", commandType: CommandType.StoredProcedure);

                return Ok(user);
            }
        }

    }
}
