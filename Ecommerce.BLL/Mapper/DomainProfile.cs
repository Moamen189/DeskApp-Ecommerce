using AutoMapper;
using Ecommerce.BLL.Models;
using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Product , ProductVM>().ReverseMap();
            CreateMap<Order, OrderVM>().ReverseMap();

            CreateMap<Customer, CustomerVM>().ReverseMap();

        }
    }
}
