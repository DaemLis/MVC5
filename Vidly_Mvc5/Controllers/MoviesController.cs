using System;
using System.Collections.Generic;
using System.Linq;
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
        IMovieRepository<Movie> movies; // direct reference to Repository Movie

        public MoviesController()
        {
            unitOfWork = new UnitOfWork();
            movies = unitOfWork.Movies;
        }

        // GET: Movie
        public ActionResult AllMovies()
        {
            var moviesList = movies.GetAll().ToList();
            return View(moviesList);
        }

        public ActionResult Details(int? id)
        {
            //if (id.HasValue)
            //{
            //    var movieList = movies.GetAll().ToList();
            //    var movie = movieList.Find(findMovie => findMovie.MovieId == id);

            //    return View(movie);
            //}

            return HttpNotFound();
        }

        // GET: Movie
        public ActionResult RandomMovie()
        {
            var moviesList = movies.GetAll().ToList();

            //var movie = moviesList.Find(find => find.MovieId == new Random().Next(1,9));
            
            //var viewModel = new RandomMovieViewModel()
            //{
            //    Movie = movie,
            //    Customers = customers
            //};

            return View();
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