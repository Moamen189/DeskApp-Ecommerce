using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
        public string Discription { get; set; }

        public string ProductUser { get; set; }

        public ICollection<Order> Orders { get; set; } 







    }
}
