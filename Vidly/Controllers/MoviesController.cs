using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            return Content("id: " + id);
        }

        //movies
        public ActionResult Index(int? indexPage, string sortBy)
        {
            if (!indexPage.HasValue)
            {
                indexPage = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(String.Format("index page:{0} sort by:{1}", indexPage, sortBy));
        }
        public ActionResult ByRealeaseDate(int year, int month)
        {
            return Content("date:"+year+"/"+month);
        }
    }
}