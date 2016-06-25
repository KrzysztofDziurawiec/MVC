using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }

        public ActionResult Edit(int id)
        {
            return Content("id: " + id);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie {Name="Forest Gump" },
                new Movie {Name="Alien" },
                new Movie {Name="Shrek" }
            };
        }

        ////movies
        //public ActionResult Index(int? indexPage, string sortBy)
        //{
        //    if (!indexPage.HasValue)
        //    {
        //        indexPage = 1;
        //    }
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }
        //    return Content(String.Format("index page:{0} sort by:{1}", indexPage, sortBy));
        //}

        [Route("movies/realease/{year}/{month:range(1,12)}")]
        public ActionResult ByRealeaseDate(int year, int month)
        {
            return Content("date:"+year+"/"+month);
        }
    }
}