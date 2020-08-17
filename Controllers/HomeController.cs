using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testAPI.Data;
using testAPI.Models;

namespace testAPI.Controllers
{
    [Route("v1")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<dynamic>> Get([FromServices] DataContext context)
        {
            var employee = new User { Id = 1, Username = "employee", Password = "employee", Role = "employee" };
            var manager = new User { Id = 2, Username = "manager", Password = "manager", Role = "manager" };
            var category = new Category { Id = 1, Title = "informática" };
            var product = new Product { Id = 1, Category = category, Title = "mouse", Price = 209.52m, Description = "periferico" };

            context.Users.Add(employee);
            context.Users.Add(manager);
            context.Categories.Add(category);
            context.Products.Add(product);
            await context.SaveChangesAsync();

            return Ok(new { message = "os exemplos foram criados" });

        }
    }
}