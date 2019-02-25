using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using Vidly_Mvc5.Models;

namespace Vidly_Mvc5.Repository
{
    public class MovieRepository : IMovieRepository<Movie>
    {
        public MovieRepository()
        {
        }

        public MovieRepository CreateContext { get { return new MovieRepository(); } }
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var result = new List<Movie>();

            using (var movieContext = new ApplicationDbContext())
            {
                result = await movieContext.Movies.Include(m => m.Genre).ToListAsync();
            }

            return result;
        }

        public async Task<Movie> NewMovie(Movie movie)
        {
            Movie result = null; 
            using (var movieContext = new ApplicationDbContext())
            {
               result = movieContext.Movies.Add(movie);
               await movieContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task DeleteMovie(int id)
        {
            using (var movieContext = new ApplicationDbContext())
            {
                var movie = movieContext.Movies.FirstOrDefaultAsync(f => f.Id == id);
                movieContext.Entry(movie).State = EntityState.Deleted;
                await movieContext.SaveChangesAsync();
            }
        }
        public async Task<Movie> UpdateMovie(Movie movie)
        {
            using (var movieContext = new ApplicationDbContext())
            {
                movieContext.Entry(movie).State = EntityState.Modified;
                await movieContext.SaveChangesAsync();
            }

            return movie;
        }


    }
}