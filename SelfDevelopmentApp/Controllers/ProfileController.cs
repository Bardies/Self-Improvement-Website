using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SelfDevelopmentApp.Models;
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

        public ProfileController(UserManager<ApplicationUser> userManager)
        {
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
                var user = userManager.FindByIdAsync(userId).Result;

                //var model = new ApplicationUser
                //{
                //    Id = user.Id,
                //    Fname = user.Fname,
                //    Lname = user.Lname,
                //    Email = user.Email,
                //    PPImageData=user.PPImageData,
                //    UserName = user.UserName,
                //    Height = user.Height,
                //    Weight = user.Weight,
                //    DOB = user.DOB,
                //    PhoneNumber = user.PhoneNumber,
                //    ToDoList = user.ToDoList,
                //    Topics = user.Topics,
                //    Habits=user.Habits

                //};
                return View(user);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser userdetails)
        {
           // string uniqueFileName = UploadedFile(userdetails);
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
                user.Email = userdetails.Email;
                //user.UserName = userdetails.UserName;
                user.PPImageData = userdetails.PPImageData;
                user.Height = userdetails.Height;
                user.Weight = userdetails.Weight;
                user.DOB = userdetails.DOB;
                user.PhoneNumber = userdetails.PhoneNumber;
                user.Topics = userdetails.Topics;
                user.ToDoList = userdetails.ToDoList;
                user.Habits = userdetails.Habits;


                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Details", "Profile");

                }
                else
                { return View("Details"); }
            }
        }
        //string fName = "C:\\Users\\zeina\\Pictures\\Pictures\\error404.jpg";
        //Image = GetPhoto(fName)
        //public static byte[] GetPhoto(string filePath)
        //{​​​​​​
        //    FileStream stream = new FileStream(
        //        filePath, FileMode.Open, FileAccess.Read);
        //    BinaryReader reader = new BinaryReader(stream);
        //    byte[] photo = reader.ReadBytes((int)stream.Length);
        //    reader.Close();
        //    stream.Close();
        //    return photo;
        //}​​​​​​
    }

}
