using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            this.OrderTime = DateTime.Now;
        }
       
        public DateTime OrderTime { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();

    }
}
