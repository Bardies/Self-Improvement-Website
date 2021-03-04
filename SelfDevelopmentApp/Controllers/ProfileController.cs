using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SelfDevelopmentApp.Models;
using SelfDevelopmentApp.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHostingEnvironment hostingEnvironment;

        public ProfileController(UserManager<ApplicationUser> userManager,
                              IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
        }
        public IActionResult Details()
        {
            var userId = userManager.GetUserId(HttpContext.User);
            if (userId == null)
            {

                return RedirectToAction("Login", "Account");
            }
            else
            {
                ApplicationUser user = userManager.FindByIdAsync(userId).Result;
                return View(user);
            }

        }
        [HttpGet]
        public IActionResult Edit()
        {
            var userId = userManager.GetUserId(HttpContext.User);
            if (userId == null)
            {

                return RedirectToAction("Login", "Account");
            }
            else
            {
                ApplicationUser user = userManager.FindByIdAsync(userId).Result;
                // user.PPImageData = null;
                EditProfileViewModel e = new EditProfileViewModel();
                e.PPImageData = null;
                e.PhoneNumber = user.PhoneNumber;
                e.Lname = user.Lname;
                e.Fname = user.Fname;
                e.DOB = user.DOB;
                e.Weight = user.Weight;
                e.Height = user.Height;
                e.PhoneNumber = user.PhoneNumber;


                return View(e);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditProfileViewModel userdetails)
        {

            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (userdetails.PPImageData != null)
                {

                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + userdetails.PPImageData.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    userdetails.PPImageData.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                var userId = userManager.GetUserId(HttpContext.User);

                var user = userManager.FindByIdAsync(userId).Result;
                if (user == null)
                {

                    return RedirectToAction("Login", "Account");
                }
                else

                {

                    user.Fname = userdetails.Fname;
                    user.Lname = userdetails.Lname;

                    user.PPImageData = uniqueFileName;
                    user.Height = userdetails.Height;
                    user.Weight = userdetails.Weight;
                    user.DOB = userdetails.DOB;
                    user.PhoneNumber = userdetails.PhoneNumber;



                    IdentityResult result = await userManager.UpdateAsync(user);


                    if (result.Succeeded)
                    {
                        return RedirectToAction("Details", "Profile");

                    }
                    else
                    { return View("Details"); }
                }

            }
            return View();
        }

    }

}
