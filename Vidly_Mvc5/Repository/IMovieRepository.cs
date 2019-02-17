using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly_Mvc5.Repository
{
    public interface IMovieRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetMovies();
        Task<T> NewMovie(T movie);
        Task<T> UpdateMovie(T movie);
        Task DeleteMovie(int id);
    }
}
