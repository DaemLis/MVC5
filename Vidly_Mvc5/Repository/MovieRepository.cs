using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Mvc5.Models;

namespace Vidly_Mvc5.Repository
{
    public class MovieRepository : IMovieRepository<Movie>
    {
        private List<Movie> context;
        public MovieRepository()
        {
            context = new List<Movie>
                {

                };
        }

        public MovieRepository CreateContext { get { return new MovieRepository(); } }
        public IEnumerable<Movie> GetAll()
        { 
            return context;
        }

        public void CreateMovie(Movie movie)
        {
            context.Add(movie);
        }

        public void DeleteMovie(int id)
        {
        // context.Remove(context.Find(find => find.MovieId == id));
        }
        public void UpdateMovie(Movie movie)
        {
            //var _movie = context.Find(find => find.MovieId == movie.MovieId);
            //_movie.Name = movie.Name;
            //_movie.Description = movie.Description;
        }


    }
}