using System;
using System.Linq;
using LearnAspNetCoreMvc.Models;
using LearnAspNetCoreMvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LearnAspNetCoreMvc.Controllers {
    [Route ("blog")]
    public class BlogController : Controller {
        private readonly BlogDataContext _blogDbContext;
        public BlogController (BlogDataContext blogDataContext) {
            this._blogDbContext = blogDataContext;
        }

        [HttpGet ("")]
        public IActionResult Index (int page = 0) {
            var pageSize = 1;
            var totalPosts = _blogDbContext.Posts.Count ();
            var totalPages = totalPosts / pageSize;
            var previousPage = page - 1;
            var nextPage = page + 1;
            ViewBag.PreviousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage >= 0;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage < totalPages;
            var posts = _blogDbContext.Posts
                .OrderByDescending (x => x.Posted)
                .Skip (pageSize * page)
                .Take (pageSize)
                .ToArray ();

            // AJAX call
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest") return PartialView (posts);//not render Viewstart
            return View (posts);
        }

        [HttpGet ("{year:min(1900)}/{month:range(1,12)}/{key}")]
        public IActionResult GetPost (int year, int month, string key) {
            var post = _blogDbContext.Posts.FirstOrDefault (x => x.Key == key);
            return View ("post", post);
        }

        [HttpGet ("create")]
        public IActionResult Create () {
            return View ();
        }

        [HttpPost ("create")]
        public IActionResult Create (Post post) {
            if (!ModelState.IsValid) return View ();
            post.Author = User.Identity.Name;
            post.Posted = DateTime.Now;
            _blogDbContext.Posts.Add (post);
            _blogDbContext.SaveChanges ();

            return RedirectToAction ("GetPost", "Blog", new {
                year = post.Posted.Year,
                    month = post.Posted.Month,
                    key = post.Key
            });
        }
    }
}