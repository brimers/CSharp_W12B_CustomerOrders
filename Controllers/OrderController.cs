using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer_Orders.Models;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Orders.Controllers
{
    public class OrderController : Controller
    {
        

        public IActionResult OrderForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Order order)
        {
            return Json(order);
        }
    }
}