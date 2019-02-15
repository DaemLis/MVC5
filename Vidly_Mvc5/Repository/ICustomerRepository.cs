using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly_Mvc5.Repository
{
    interface ICustomerRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void CreateCustomer(T customer);
        void UpdateCustomer(T customer);
        void DeleteCustomer(int id);
    }
}
