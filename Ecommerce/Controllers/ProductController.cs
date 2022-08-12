using AutoMapper;
using Ecommerce.BLL.Interfaces;
using Ecommerce.BLL.Models;
using Ecommerce.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGenericRepository<Product> _repository;
        //private readonly IOrderProductRepo _productRepo;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> repository/*, IOrderProductRepo productRepo*/, IMapper mapper)
        {
            _repository = repository;
            //_productRepo = productRepo;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _repository.GetAll();
            var mappedOrder = _mapper.Map<IEnumerable<ProductVM>>(data);
            return View(mappedOrder);
        }

        public async Task<IActionResult> Details(int ? id)
        {
            if (id == null)
                return NotFound();
            var Product = await _repository.GetById(id);
            if (Product == null)
                return NotFound();
            var mappedOrder = _mapper.Map<ProductVM>(Product);

            return View(mappedOrder);

        }

        public IActionResult Create()
        {
            return View();  
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductVM product)
        {
            if (ModelState.IsValid)
            {
                var mappedData = await _repository.Create(_mapper.Map<Product>(product));
               
                return RedirectToAction("Index");



            }
            return View(product);
        }


        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();
            var data = await _repository.GetById(id);

            if (data == null)
                return BadRequest();
            return View(_mapper.Map<ProductVM>(data));

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductVM product)
        {
            if (ModelState.IsValid)
            {
                await _repository.Update(_mapper.Map<Product>(product));
                return  RedirectToAction("Index");
            }

            return View(product);

        }
        

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var data = await _repository.GetById(id);
          

            await _repository.Delete(data);

            return RedirectToAction("Index");
        }

    }
}
