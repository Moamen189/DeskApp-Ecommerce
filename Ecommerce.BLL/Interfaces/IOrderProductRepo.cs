using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Interfaces
{
    public interface IOrderProductRepo
    {
        void Create(int OrderId, int ProductId);  
    }
}
