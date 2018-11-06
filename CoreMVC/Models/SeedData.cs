using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Models
{
    public static class SeedData
    {
        public static void Initailize(IServiceProvider serviceProvider)
        {
            using (var context=new CoreMVCContext(
                serviceProvider.GetRequiredService<DbContextOptions<CoreMVCContext>>()))
            {
                if (context.Movie.Any())
                    return;

                context.Movie.Add(
                    new Movie {
                        Title = "Default Movie",
                        ReleaseDate = DateTime.Parse("1993-10-31"),
                        Genre="Comedy",
                        Price=7.99M
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
