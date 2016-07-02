using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name ="Movie title")]
        public String Name { get; set; }

        [Required]
        [Display(Name ="Release date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        public Genre Genre { get; set; }

        [Display(Name ="Genre")]
        [Required]
        public int GenreId { get; set; }

        [Range(1,20)]
        [Required]
        [Display(Name ="Number in stock")]
        public int Stock { get; set; }
    }
}