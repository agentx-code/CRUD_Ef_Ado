using CRUDEfAdo.Net.Models;
using CRUDEfAdo.Net.Services;
using CRUDEfAdo.Net.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUDEfAdo.Net.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _environment;
        public HomeController(IUserService userService,IWebHostEnvironment environment)
        {
            _userService = userService;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            var user =  await _userService.GetAllAsync();
            return View(user);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (User user, IFormFile? Images)
        {
            Console.WriteLine("Image = " + (Images == null ? "NULL" : Images.FileName));
            Console.WriteLine("Image Length = " + (Images?.Length ?? 0));

            if (user.Id > 0)
            {

                await _userService.UpdateAsync(user);
                return RedirectToAction("Index");
            }
            else
            {
                if (Images != null && Images.Length > 0)
                {
                    string folder = Path.Combine(_environment.WebRootPath, "Images");
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Images.FileName);

                    string filePath = Path.Combine(folder, fileName);
                    using (var stream = new FileStream(
                            filePath, FileMode.Create))
                    {
                        await Images.CopyToAsync(stream);
                    }
                    user.Images = "/images/" + fileName;
                }
                await _userService.CreateAsync(user);
                return RedirectToAction("Index");
                
            }
        }
        
        public async Task<IActionResult> Delete(int Id)
        {
                
            await _userService.DeleteAsync(Id);
           return RedirectToAction("Index");
        }
    }
}
