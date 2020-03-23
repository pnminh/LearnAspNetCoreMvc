using LearnAspNetCoreMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnAspNetCoreMvc.Repositories
{
    public class BlogDataContext:DbContext
    {
        public DbSet<Post> Posts {get;set;}
        public DbSet<Comment> Comments{get;set;}
        public BlogDataContext(DbContextOptions<BlogDataContext> options):base(options){
            Database.EnsureCreated();
        }
    }
}