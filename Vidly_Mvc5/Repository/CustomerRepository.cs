using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Vidly_Mvc5.Models;

namespace Vidly_Mvc5.Repository
{
    public class CustomerRepository : ICustomerRepository<Customer>
    {
        public CustomerRepository()
        {              
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var result = new List<Customer>();

            using (var customerContext = new ApplicationDbContext())
            {
                result = await customerContext.Customers.Include(c => c.MembershipType).ToListAsync(); //Include - Eager
            }

            return result;
        }
        public async Task NewCustomer(Customer customer)
        {
            Customer result = null;

            using (var customerContext = new ApplicationDbContext())
            {
                result = customerContext.Customers.Add(customer);
                await customerContext.SaveChangesAsync();
            }

          //  return result;
        }
        public async Task DeleteCustomer(int id)
        {
            using (var customerContext = new ApplicationDbContext())
            {
                var customer = await customerContext.Customers.FirstOrDefaultAsync(find => find.Id == id);
                customerContext.Entry(customer).State = EntityState.Deleted;
                await customerContext.SaveChangesAsync();
            }
        }
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            using (var customerContext = new ApplicationDbContext())
            {
                customerContext.Entry(customer).State = EntityState.Modified;
                await customerContext.SaveChangesAsync();
            }

            return customer;
        }
    }
}