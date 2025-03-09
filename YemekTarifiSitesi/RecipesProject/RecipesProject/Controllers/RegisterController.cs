using DTOLayer.DTOs.UserDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RecipesProject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterUserDTO model)
        {
            if (string.IsNullOrEmpty(model.password))
                //sistem password değerini null okuyabildiğinden dolayı 
            {
                return View(); 
            }
            else
            {

                if (ModelState.IsValid) 
                { 
                if (model.picture!=null)//resim seçiliyse
                {
                    var source = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(model.picture.FileName);
                    var imageName = Guid.NewGuid() + extension;
                    var saveLocation = source + "/wwwroot/imgfile/" + imageName;
                    var stream = new FileStream(saveLocation, FileMode.Create);
                    await model.picture.CopyToAsync(stream);//kopyasını oluştur
                    AppUser user = new AppUser()
                    {
                        Email = model.mail,
                        Name = model.name,
                        Surname = model.surname,
                        UserName = model.username,
                        ProfileImage = "/imgfile/" + imageName,
                    };
                    var result = await _userManager.CreateAsync(user, model.password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                }
            }
            }
            return View(model);
        }
    }
}
