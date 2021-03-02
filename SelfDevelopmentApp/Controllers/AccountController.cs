using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SelfDevelopmentApp.Models;
using SelfDevelopmentApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Controllers
{
    
    public class AccountController : Controller
    {
      

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Fname=model.Fname,
                    Lname=model.Lname
                    


                };

               
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

               
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
        /* [HttpPost]
         public async Task<IActionResult> Logout()
         {
             await signInManager.SignOutAsync();
             return RedirectToAction("Index", "Home");
         }

         [HttpGet]
         public IActionResult Login()
         {
             return View();
         }

         [HttpPost]
         public async Task<IActionResult> Login(LoginViewModel model)
         {
             if (ModelState.IsValid)
             {
                 var result = await signInManager.PasswordSignInAsync(
                     model.Email, model.Password, model.RememberMe, false);

                 if (result.Succeeded)
                 {
                     return RedirectToAction("index", "home");
                 }

                 ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
             }

             return View(model);
         }
        */
        //[HttpPost]
        //public async Task<IActionResult> Logout()
        //{
        //    await signInManager.SignOutAsync();
        //    return RedirectToAction("index", "home");
        //}

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

        [HttpGet]
      //  [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
      //  [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(user);
        }

    }
}
    

