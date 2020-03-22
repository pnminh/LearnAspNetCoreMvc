using LearnAspNetCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnAspNetCoreMvc.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("{year:min(1900)}/{month:range(1,12)}/{key}")]
        public IActionResult GetPost(int year, int month, string key){
            return View();
        }

    }
}