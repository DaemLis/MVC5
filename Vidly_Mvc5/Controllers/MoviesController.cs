using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vidly_Mvc5.Models;
using Vidly_Mvc5.Repository;
using Vidly_Mvc5.ViewModels;

namespace Vidly_Mvc5.Controllers
{
    public class MoviesController : Controller
    {

        IUnitOfWork unitOfWork; // direct reference to UoW pattern
 
        public MoviesController()
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: Movie
        public async Task<ActionResult> GetMovies()
        {
            var moviesList = await unitOfWork.Movies.GetMovies();
            return View(moviesList);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id.HasValue)
            {
                var movieList = await unitOfWork.Movies.GetMovies();
                var movie = movieList.FirstOrDefault(f => f.Id == id);
                return View(movie);
            }

            return HttpNotFound();
        }

        // GET: Movie
        public async Task<ActionResult> RandomMovie()
        {
            var moviesList = await unitOfWork.Movies.GetMovies();
            int rand = new Random().Next(1,7);
            var movie = moviesList.FirstOrDefault(find => find.NumberInStock == rand);

            return View(movie);
            //return View("Random", viewModel);
            #region return oprions
            //return RedirectToAction("Index", "Home", new { page = 1, sortby = "name" });
            //return View(movie);
            //return new EmptyResult();
            //return HttpNotFound();
            //return Content("MegaMind!");
            #endregion
        }

        public ActionResult MovieOnline()
        {
            return View();
        }

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int? year, int? month)
        {
            return Content(year + "/" + month);
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