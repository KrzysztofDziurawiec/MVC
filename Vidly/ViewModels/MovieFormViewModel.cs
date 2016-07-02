using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        //creating individual atribiutes of movie class
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Movie title")]
        public String Name { get; set; }

        [Required]
        [Display(Name = "Release date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int? GenreId { get; set; }

        [Range(1, 20)]
        [Required]
        [Display(Name = "Number in stock")]
        public int? Stock { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
            Stock = movie.Stock;
        }
    }
}