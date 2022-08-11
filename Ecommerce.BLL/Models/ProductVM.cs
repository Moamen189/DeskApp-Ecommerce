using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Models
{
    public class ProductVM
    {
        public int ID { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string Color { get; set; }
        [Required]

        public string Size { get; set; }
        [Required]

        public double Price { get; set; }
        [Required]

        public int Quantity { get; set; }
        public string Discription { get; set; }

        public string ProductUser { get; set; }

        public virtual ICollection<Order> Orders { get; set; } 
    }
}
