using System;
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
            return View(new[]{
                new Post {
                    Title = "My blog post",
                    Posted = DateTime.Now,
                    Author = "John Doe",
                    Body = "This is a great blog post, don't you think?"
                },
                new Post {
                    Title = "My 2nd blog post",
                    Posted = DateTime.Now,
                    Author = "John Doe",
                    Body = "This is another great blog post, don't you think?"
                },
            });
        }
        [HttpGet("{year:min(1900)}/{month:range(1,12)}/{key}")]
        public IActionResult GetPost(int year, int month, string key)
        {
            return View("post", new Post
            {
                Title = "My blog post",
                Posted = DateTime.Now,
                Author = "John Doe",
                Body = "This is a great blog post, don't you think?"
            });
        }

    }
}