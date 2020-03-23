using System;
using System.Collections.Generic;
using System.Linq;
using LearnAspNetCoreMvc.Models;
using LearnAspNetCoreMvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LearnAspNetCoreMvc.apis {
    [Route ("api/posts/{postKey}/[controller]")]
    public class CommentsController : Controller {
        private readonly BlogDataContext _dbContext;
        public CommentsController (BlogDataContext dbContext) {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public List<Comment> Get (string postKey) {
            return this._dbContext.Comments.Where (x => x.Post.Key == postKey).ToList ();
        }

        [HttpGet ("{id}")]
        public Comment GetById (long id) {
            return this._dbContext.Comments.FirstOrDefault (x => x.Id == id);
        }

        [HttpPost]
        public Comment Post (string postKey, [FromBody] Comment comment) {
            var post = _dbContext.Posts.FirstOrDefault (x => x.Key == postKey);
            if (post == null) return null;
            comment.Post = post;
            comment.Posted = DateTime.Now;
            comment.Author = User.Identity.Name;
            _dbContext.Comments.Add (comment);
            _dbContext.SaveChanges ();
            return comment;

        }

        [HttpPut ("{id}")]
        public IActionResult Put (long id, [FromBody] Comment value) {
            var comment = _dbContext.Comments.FirstOrDefault (x => x.Id == id);
            if (comment == null) return NotFound ();
            comment.Body = value.Body;
            _dbContext.SaveChanges ();
            return Ok ();
        }

        [HttpDelete ("{id}")]
        public void Delete (long id) {
            var comment = _dbContext.Comments.FirstOrDefault (x => x.Id == id);
            if (comment != null) {
                _dbContext.Comments.Remove (comment);
                _dbContext.SaveChanges ();
            }
        }
    }
}