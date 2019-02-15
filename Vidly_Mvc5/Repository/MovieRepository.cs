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
                  new Movie {MovieId = 1, Name = "Carter", Description = "Something about Carter!" },
                  new Movie {MovieId = 2, Name = "Our Time", Description = "Something about Our time!" },
                  new Movie {MovieId = 3, Name = "Who is Next", Description = "Something about Who is next!" },
                  new Movie {MovieId = 4, Name = "Shrek", Description = "Something about Shrek!" },
                  new Movie {MovieId = 5, Name = "Come to me", Description = "Something about Come to me!" },
                  new Movie {MovieId = 6, Name = "MegaMind", Description = "Something about MegaMind!" },
                  new Movie {MovieId = 7, Name = "Today or Tomorrow", Description = "Something about Tomorrow!" },
                  new Movie {MovieId = 8, Name = "Who am I", Description = "Something about Who am I" },
                  new Movie {MovieId = 9, Name = "I think therefore I am", Description = "Something about movie" },
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
         context.Remove(context.Find(find => find.MovieId == id));
        }
        public void UpdateMovie(Movie movie)
        {
            var _movie = context.Find(find => find.MovieId == movie.MovieId);
            _movie.Name = movie.Name;
            _movie.Description = movie.Description;
        }


    }
}