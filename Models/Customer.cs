using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_Orders.Models
{
    public class Customer
    {
        public int? Id { get; set; } // optional, can be null

        public string Name { get; set; }

        public string Email { get; set; }

        public List<Order> Orders { get; set; }
    }
}
