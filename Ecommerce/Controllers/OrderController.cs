using AutoMapper;
using Ecommerce.BLL.Interfaces;
using Ecommerce.BLL.Models;
using Ecommerce.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly IGenericRepository<Order> _repository;
        private readonly IMapper _mapper;

        public OrderController(IGenericRepository<Order> repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _repository.GetAll();
            var mappedOrder = _mapper.Map<IEnumerable <OrderVM>>(data);
            return View(mappedOrder);
        }

        public async Task<IActionResult> Details(int? id)
        {
           if(id == null)
                return NotFound();
           var order = await _repository.GetById(id);

            if (order == null)
                return NotFound();
            return View(order);
        }


        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(OrderVM Order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var mappedData = await _repository.Create(_mapper.Map<Order>(Order));
        //        foreach (var item in Order.ProductId)
        //        {


        //        }


        //    }
        //}
    }
}
