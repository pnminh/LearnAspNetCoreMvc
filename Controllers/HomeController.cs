using System;
using Microsoft.AspNetCore.Mvc;
namespace LearnAspNetCoreMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult index()
        {
            return View();
        }
    }
}