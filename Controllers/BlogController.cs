using LearnAspNetCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnAspNetCoreMvc.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        [HttpGet("")]
        public IActionResult index()
        {
            return View();
        }
        [HttpGet("getPerson")]
        public IActionResult GetPerson(){
            return View(new Person{FirstName="Minh",LastName="Pham"});
        }

    }
}