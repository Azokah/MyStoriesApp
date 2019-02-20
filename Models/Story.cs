using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMyStories.Models
{
    public class Story
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Content { get; set; }
        
    }
}