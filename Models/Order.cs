﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_Orders.Models
{
    public class Order
    {

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; } 
        public Customer Customer { get; set; }
    }
}
