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

        //return View();
        }

        public async Task<ActionResult> New()
        {
            var membershipTypes = unitOfWork.MembershipTypes;

            var viewModel = new CustomerViewModel()
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Customer customer)
        {
            await unitOfWork.Customers.NewCustomer(customer);

            return RedirectToAction("AllCustomers", "Customers");
        }


        public ActionResult Afisha()
        {
            return View();
        }
    }
}