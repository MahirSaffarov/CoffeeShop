using CoffeeShop.Models;
using CoffeeShop.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            if(request.Age < 18)
            {
                ModelState.AddModelError("Age","You are Result");
                return View(request);
            }
            AppUser user = new()
            {
                FullName = request.FullName,
                Address = request.Address,
                Email = request.Email,
                UserName = request.UserName,
                Age = request.Age
            };
            
            var result = await _userManager.CreateAsync(user,request.Password);

            
                if (!result.Succeeded)
                {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(request);
            }
            await _signInManager.SignInAsync(user,false);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
