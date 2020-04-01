using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Customer_Orders.Models;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Orders.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {

            var c1 = new Customer
            {
                Name = "John",
                Email = "a1@b.com"

            };

            var customers = new List<Customer> {c1, c1, c1};
            return View(customers);
        }

        public IActionResult CustomerForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Customer customer)
        {
            return Json (customer);
        }
    }
}