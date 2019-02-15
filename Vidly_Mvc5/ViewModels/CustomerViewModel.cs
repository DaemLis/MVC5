using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Vidly_Mvc5.Models;

namespace Vidly_Mvc5.ViewModels
{
    public class CustomerViewModel
    {
        public  async Task<List<Customer>> GetCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith"},
                new Customer { Id = 2, Name = "Mary Williams"},
                new Customer { Id = 3, Name = "Artur John"},
                new Customer { Id = 4, Name = "Johnatan Nollan"},
                new Customer { Id = 5, Name = "Morgan Freeman"},
            };

            return  await Task.Run(()=> customers);
        }
    }
}