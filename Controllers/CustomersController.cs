using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Customer_Orders.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Customer_Orders.Controllers
{
    public class CustomersController : Controller
    {
        private Database _dbContext;

        public CustomersController()
        {
            _dbContext = new Database(); //2:30
        }

        public IActionResult Index()
        {
            return View(_dbContext.Customers.ToList()); //3:00
        }

        public IActionResult CustomerForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Customer customer)
        {

            //  todo: validation
            // check to see if the action is add or edit???
            //  if id = null, then it is adding. otherwise, editting

            if (customer.Id == null)
            {
                _dbContext.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _dbContext.Customers.Find(customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Email = customer.Email;
            }

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var customer = _dbContext.Customers.Find(id); //  this method only works if there is a primary key
            if (customer == null)
                return NotFound();

            return View("CustomerForm", customer);
        }

        public IActionResult Delete(int id) //  important to call the id parameter
        {
            var customer = _dbContext.Customers.Find(id); //  .Find() only works if there is a primary key
            if (customer == null)
                return NotFound(); // intentionally throws a 404 error

            // todo: you want to make sure the customers dont have any orders
            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SaveOrder(Order order, int customerId)
        {

            var customer = _dbContext.Customers.Find(customerId); //  this method only works if there is a primary key
            if (customer == null)
                return NotFound();
            order.Customer = customer;

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult CreateOrder(int Id)
        {

            ViewBag.CustomerId = Id;
            return View("OrderForm");
        }

        public IActionResult Orders(int id)
        {
            var customer = _dbContext.Customers.Include(c=>c.Orders).SingleOrDefault(c=>c.Id == id); //  lazy loading. loaded customer but no related items
            if (customer == null)
                return NotFound();

            return View(customer.Orders);
        }

    }
}