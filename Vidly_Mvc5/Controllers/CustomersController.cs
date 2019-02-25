using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vidly_Mvc5.Models;
using Vidly_Mvc5.Repository;
using Vidly_Mvc5.ViewModels;

namespace Vidly_Mvc5.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        //private readonly ICustomerRepository customers;
        // GET: Customers

        public CustomersController()
        {
            unitOfWork = new UnitOfWork();
        }

        public async Task<ActionResult> AllCustomers()
        {
            var customersList = await unitOfWork.Customers.GetAll();
        
            return View(customersList);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id.HasValue)
            {
                var customerList = await unitOfWork.Customers.GetAll();
                var customer = customerList.FirstOrDefault(find => find.Id == id);

                return View(customer);
            }
            else { return HttpNotFound(); }
        }

        public async Task<ActionResult> New()
        {
            var membershipTypes = unitOfWork.MembershipTypes;

            var viewModel = new CustomerViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes.ToList()
            };

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Save(CustomerViewModel customerViewmodel)
        {
            Customer customer = customerViewmodel.Customer;

            if (customer.Id == 0)//but that id is not currently in a form 
                 await unitOfWork.Customers.NewCustomer(customer);
            else await unitOfWork.Customers.UpdateCustomer(customer);

                return RedirectToAction("AllCustomers", "Customers");

        }

        public async Task<ActionResult> Edit(int id)
        {
            var customerList = await unitOfWork.Customers.GetAll();
            var customer = customerList.SingleOrDefault(f => f.Id == id);
            if (customer == null)
            {
                return HttpNotFound(); // we get standart 404 error
            }

            var customerViewModel = new CustomerViewModel
            {
                Customer = customer,
                MembershipTypes = unitOfWork.MembershipTypes.ToList()
            };

            return View("CustomerForm", customerViewModel);
        }

        public ActionResult Afisha()
        {
            return View();
        }
    }
}