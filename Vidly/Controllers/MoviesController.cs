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