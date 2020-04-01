using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Customer_Orders.Models
{
    public class Database : DbContext
    {
        //  todo: 1. declare props (tables)

        //  one to many relationship

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }


        //  todo: 2. setup the connection string

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Integrated Security=SSPI;Persist Security Info= False;Initial Catalog=Customers;
                Data Source=DESKTOP-7082PM8\STEPHENBRIMERSQL");
        }
    }
}
