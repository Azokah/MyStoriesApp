using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMyStories.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcStoryContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcStoryContext>>()))
            {
                // Look for any movies.
                if (context.story.Any())
                {
                    return;   // DB has been seeded
                }

                context.story.AddRange(
                    new Story
                    {
                        Title = "My first story",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Content = "This is my first story, made from the SeedData.",
                    },

                    new Story
                    {
                        Title = "The second story ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Content = "This is another story made from the SeedData",
                    },

                    new Story
                    {
                        Title = "Daily entry number three",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Content = "This is only a test entry",
                    },

                    new Story
                    {
                        Title = "Last of today",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Content = "This is a very nice test",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}