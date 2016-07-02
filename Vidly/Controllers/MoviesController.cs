using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //Add new Movie
        public ActionResult New()
        {
            var ganre = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = ganre
            };
            return View("MovieForm", viewModel);
        }

        //Edit Movie
        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
               return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        //save Movie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDB = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDB.Name = movie.Name;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.GenreId = movie.GenreId;
                movieInDB.Stock = movie.Stock;
            }      
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m=> m.Genre).SingleOrDefault(m=> m.Id==Id);
            if (movie != null)
                return View(movie);
            else
                return HttpNotFound();
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