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
                        Title = "My first story in this App!",
                        ReleaseDate = DateTime.Parse("2019-2-18"),
                        Content = "This is my first story, in this app. It was made from the SeedData and is fairly simple. Here is a picture of my motorcycle.",
                        imgPath = "Tenere.jpg"
                    },

                    new Story
                    {
                        Title = "The second story, it is about friends!",
                        ReleaseDate = DateTime.Parse("2019-2-19"),
                        Content = "This is another story made from the SeedData. Today i went out with friends!",
                        imgPath = "beermug.png"
                    },

                    new Story
                    {
                        Title = "Daily entry number three, i went riding!",
                        ReleaseDate = DateTime.Parse("2019-2-20"),
                        Content = "Today i went out and rode with a friend, he has an amazing 94' Suzuki DR350.",
                        imgPath = "Suzuki.jpg"
                    },

                    new Story
                    {
                        Title = "Last of today",
                        ReleaseDate = DateTime.Parse("2019-2-21"),
                        Content = "Today i played some pen and paper rpg, i've been the dungeon master since kid.",
                        imgPath = "tolkien.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}