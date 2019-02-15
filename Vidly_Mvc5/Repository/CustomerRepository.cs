using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Mvc5.Models;

namespace Vidly_Mvc5.Repository
{
    public class CustomerRepository : ICustomerRepository<Customer>
    {
        private List<Customer> context;
        public CustomerRepository()
        {
            context = new List<Customer>
                {
                  new Customer { Id = 1, Name = "John Smith"},
                  new Customer { Id = 2, Name = "Mary Williams"},
                  new Customer { Id = 3, Name = "Artur John"},
                  new Customer { Id = 4, Name = "Johnatan Nollan"},
                  new Customer { Id = 5, Name = "Morgan Freeman"},
                  new Customer { Id = 6, Name = "Megan Sank"},
                  new Customer { Id = 7, Name = "Tidy Mark"},
                  new Customer { Id = 8, Name = "William Colian"},
                  new Customer { Id = 9, Name = "Ihitay Mike"},
                };
        }

        public void CreateCustomer(Customer customer)
        {
            context.Add(customer);
        }

        public void DeleteCustomer(int id)
        { 
            context.Remove(context.Find(find => find.Id == id));
        }

        public IEnumerable<Customer> GetAll()
        {
            return context;
        }

        public void UpdateCustomer(Customer customer)
        {
            var _customer = context.Find(find => find.Id == customer.Id);
            _customer.Name = customer.Name;
        }
    }
}