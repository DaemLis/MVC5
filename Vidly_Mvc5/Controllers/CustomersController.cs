using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_Mvc5.Models;
using Vidly_Mvc5.Repository;

namespace Vidly_Mvc5.Controllers
{
    public class CustomersController : Controller
    {
        IUnitOfWork unitOfWork;
        ICustomerRepository<Customer> customers;
        // GET: Customers

        public CustomersController()
        {
            unitOfWork = new UnitOfWork();
            customers = unitOfWork.Customers;
        }

        public ActionResult AllCustomers()
        {
            var customersList = customers.GetAll().ToList();
           
            return View(customersList);
        }

        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var customerList = customers.GetAll().ToList();
                var customer = customerList.Find(result => result.Id == id);

                return View(customer);
            }
            else { return HttpNotFound(); }

        //return View();
        }

        public ActionResult Afisha()
        {
            return View();
        }
    }
}