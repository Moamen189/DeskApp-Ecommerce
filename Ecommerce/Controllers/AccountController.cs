using Ecommerce.BLL.Models;
using Ecommerce.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Customer> _userManager;
        private readonly SignInManager<Customer> _signInManager;

        public AccountController(UserManager<Customer> userManager , SignInManager<Customer> SignInManager)
        {
            _userManager = userManager;
            _signInManager = SignInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Register(RegisterView registerVm)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer
                {
                    UserName = registerVm.Email,
                    Email = registerVm.Email,
                };
                var result = await _userManager.CreateAsync(customer , registerVm.Password);
                if (result.Succeeded)
                    RedirectToAction(nameof(Login));
                foreach ( var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty,error.Description);
                }

            }
            return View(registerVm);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVm)
        {
            if (ModelState.IsValid)
            {
                var customer = await _userManager.FindByEmailAsync(loginVm.Email);
                if (customer != null)
                {
                    await _signInManager.SignInAsync(customer, true);
                    return RedirectToAction("Index", "Product");
                }
                ModelState.AddModelError(string.Empty, "InValid Email");
            }
            return View(loginVm);
        }
        public async new Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
           return RedirectToAction(nameof(Login));

        }
    }
}

