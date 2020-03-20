using System;
using Microsoft.AspNetCore.Mvc;
namespace LearnAspNetCoreMvc.Controllers
{
    public class HomeController : Controller
    {
        public String index()
        {
            return "Hello from Home Controller";
        }
        public IActionResult echo(string id)
        {
            return new ContentResult { Content = id };
        }
        public IActionResult echoWithDefault(string id = "default"){
            return new ContentResult {Content = id};
        }
        public IActionResult echoWithNullable(int? id){
            return new ContentResult {Content = id==null?"NULL":id.ToString()};
        }
    }
}