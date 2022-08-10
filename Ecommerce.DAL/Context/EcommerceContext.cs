using Ecommerce.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Context
{
    public class EcommerceContext:DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> Options):base(Options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

    }
}
