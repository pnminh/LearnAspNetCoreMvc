using System;
using System.Linq;
using LearnAspNetCoreMvc.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LearnAspNetCoreMvc.Models
{
    public class SeedDataSpecial
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var specialDbContext = new SpecialDataContext(serviceProvider.GetRequiredService<DbContextOptions<SpecialDataContext>>()))
            {
                if (specialDbContext.Specials.Any())
                {
                    return;
                }
                specialDbContext.AddRange(
                    new Special
                    {
                        Key = "calm",
                        Name = "California Calm Package",
                        Type = "Day Spa Package",
                        Price = 250,
                    },
                    new Special
                    {
                        Key = "desert",
                        Name = "From Desert to Sea",
                        Type = "2 Day Salton Sea",
                        Price = 350,
                    },
                    new Special
                    {
                        Key = "backpack",
                        Name = "Backpack Cali",
                        Type = "Big Sur Retreat",
                        Price = 620,
                    },
                    new Special
                    {
                        Key = "taste",
                        Name = "Taste of California",
                        Type = "Tapas & Groves",
                        Price = 250,
                    }
                );
                specialDbContext.SaveChanges();
            }
        }
    }
}