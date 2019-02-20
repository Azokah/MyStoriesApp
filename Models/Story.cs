using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMyStories.Models
{
    public class Story
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        [Required]        
        public DateTime ReleaseDate { get; set; }

        public string Content { get; set; }

        [Display(Name = "Image")] 
        public string imgPath{ get; set; }
        
    }
}