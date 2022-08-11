using Ecommerce.BLL.Interfaces;
using Ecommerce.DAL.Context;
using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Repository
{
    public class OrderProductRepo : IOrderProductRepo
    {
        private readonly EcommerceContext context;

        public OrderProductRepo(EcommerceContext context)
        {
            this.context = context;
        }
        public void Create(int OrderId, int ProductId)
        {
            var data = new OrderProduct() { OrderId = OrderId, ProductId = ProductId };
            context.OrderProducts.Add(data);
            context.SaveChanges();
        }
    }
}
