using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearnAspNetCoreMvc.Repositories
{
    public class IdentityDataContext:IdentityDbContext<IdentityUser>
    {
        public IdentityDataContext(DbContextOptions<IdentityDataContext> options):base(options){
            Database.EnsureCreated();
        }
    }
}