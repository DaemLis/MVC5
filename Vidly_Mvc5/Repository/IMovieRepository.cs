using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly_Mvc5.Repository
{
    interface IMovieRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void CreateMovie(T movie);
        void UpdateMovie(T movie);
        void DeleteMovie(int id);
    }
}
