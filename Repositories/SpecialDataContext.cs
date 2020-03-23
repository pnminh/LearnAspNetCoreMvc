using LearnAspNetCoreMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnAspNetCoreMvc.Repositories
{
    public class SpecialDataContext : DbContext
    {
        public DbSet<Special> Specials { get; set; }
        public SpecialDataContext(DbContextOptions<SpecialDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}