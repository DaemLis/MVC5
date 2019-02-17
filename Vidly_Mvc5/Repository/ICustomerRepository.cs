using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly_Mvc5.Repository
{
    public interface ICustomerRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task NewCustomer(T customer);
        Task<T> UpdateCustomer(T customer);
        Task DeleteCustomer(int id);
    }
}
