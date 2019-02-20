using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcMyStories.Models
{
    public class MvcStoryContext : DbContext
    {
        public MvcStoryContext (DbContextOptions<MvcStoryContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMyStories.Models.Story> story { get; set; }
    }
}