using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
         Task<IEnumerable<T>> GetAll();
         Task<T> GetById(int? id);

         Task<int> Create(T obj);
         Task<int> Update(T obj);
        Task<int> Delete(T obj);

    }
}
