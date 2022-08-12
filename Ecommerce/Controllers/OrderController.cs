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
        private readonly IOrderProductRepo _productRepo;
        private readonly IMapper _mapper;

        public OrderController(IGenericRepository<Order> repository ,IOrderProductRepo productRepo ,IMapper mapper)
        {
            _repository = repository;
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _repository.GetAll();
            var mappedOrder = _mapper.Map<IEnumerable <OrderVM> >(data);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderVM Order)
        {
            if (ModelState.IsValid)
            {
                var mappedData = await _repository.Create(_mapper.Map<Order>(Order));
                foreach (var item in Order.ProductId)
                {
                    _productRepo.Create(mappedData, item);

                }
                return RedirectToAction("Index");

                 

            }
            return View(Order);
        }
        [HttpPost]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var data = await _repository.GetById(id);
            await _repository.Delete(data);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            var data = await _repository.GetById(id);

            if(data == null)
                return BadRequest();
            return View(_mapper.Map<OrderVM>(data));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(OrderVM order)
        {
            if (ModelState.IsValid)
            {
                 await _repository.Update(_mapper.Map<Order>(order));
               
                return RedirectToAction("Index");



            }
            return View(order);

        }


    }
}
