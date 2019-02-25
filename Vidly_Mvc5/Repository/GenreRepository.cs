using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Vidly_Mvc5.Models;

namespace Vidly_Mvc5.Repository
{
    public class GenreRepository
    {
        public async Task<IEnumerable<Genre>> GetGenres()
        {
            var result = new List<Genre>();

            using (var customerContext = new ApplicationDbContext())
            {
                result = await customerContext.Genres.ToListAsync();
            }

            return result;
        }
    }
}