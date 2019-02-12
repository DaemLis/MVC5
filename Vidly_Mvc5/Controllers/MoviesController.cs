using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_Mvc5.Models;
using Vidly_Mvc5.ViewModels;

namespace Vidly_Mvc5.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer() { Id = 1, Name = "VL" },
                new Customer() { Id = 2, Name = "LV" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

            #region return oprions
            //return RedirectToAction("Index", "Home", new { page = 1, sortby = "name" });
            //return View(movie);
            //return new EmptyResult();
            //return HttpNotFound();
            //return Content("MegaMind!");

            #endregion
        }

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int? year, int? month)
        {
            return Content(year + "/" + month);
        }


        public ActionResult Edit(int id)
        {
            return Content("id:" + id.ToString());
        }

        // movies this action 
        // will return a list of movies from dataBase
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex={0}&sortBy{1}", pageIndex, sortBy));
        }
    }
}