using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer {Id=1, Name="Krzysztof Dziurawiec" },
                new Customer {Id=2, Name="Keeya Arjel" },
                new Customer {Id=3, Name="Binita Chhetri" }
            };
            var viewModel = new CustomerListViewModel
            {
                Customers = customers
            };
            return View(viewModel);
        }

        public ActionResult Details(int Id)
        {
            var customers = new List<Customer>
            {
                new Customer {Id=1, Name="Krzysztof Dziurawiec" },
                new Customer {Id=2, Name="Keeya Arjel" },
                new Customer {Id=3, Name="Binita Chhetri" }
            };
            var customer = customers.Where(x => x.Id == Id).FirstOrDefault();
            if (customer != null)
                return View(customer);
            else
                return HttpNotFound(); 
        }
    }
}