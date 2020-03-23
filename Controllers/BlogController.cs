using System;
using System.Linq;
using LearnAspNetCoreMvc.Models;
using LearnAspNetCoreMvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LearnAspNetCoreMvc.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        private readonly BlogDataContext _blogDbContext;
        public BlogController(BlogDataContext blogDataContext)
        {
            this._blogDbContext = blogDataContext;
        }
        [HttpGet("")]
        public IActionResult Index(int page = 0)
        {
            var posts = _blogDbContext.Posts.OrderByDescending(x => x.Posted).Take(5).ToArray();
            return View(posts);
        }
        [HttpGet("{year:min(1900)}/{month:range(1,12)}/{key}")]
        public IActionResult GetPost(int year, int month, string key)
        {
            var post = _blogDbContext.Posts.FirstOrDefault(x => x.Key == key);
            return View("post", post);
        }
        [HttpGet("create")]
        public IActionResult Create(){
            return View();
        }
        [HttpPost("create")]
        public IActionResult Create(Post post){
            if(!ModelState.IsValid)return View();
            post.Author = User.Identity.Name;
            post.Posted = DateTime.Now;
            _blogDbContext.Posts.Add(post);
            _blogDbContext.SaveChanges();

            return RedirectToAction("GetPost","Blog", new {
                year = post.Posted.Year,
                month = post.Posted.Month,
                key = post.Key
            });
        }
    }
}