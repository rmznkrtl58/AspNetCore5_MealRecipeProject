using DTOLayer.DTOs.UserDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace RecipesProject.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/[controller]/[action]/{id?}")]
	public class DefaultController : Controller
	{   //Profil Bilgilerimizi Güncelleyeceğimiz Alandır
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
        public DefaultController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
		public async Task<IActionResult> Index()
		{
			ViewBag.t2 = "Profil";
			ViewBag.t3 = "Profil Bilgilerim";
			var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
			UpdateUserDTO model = new UpdateUserDTO()
			{
				 userName=findUser.UserName,
				 name=findUser.Name,
				 surname=findUser.Surname,
				 phoneNumber=findUser.PhoneNumber,
				 mail=findUser.Email,
				 imageUrl=findUser.ProfileImage,
				 about=findUser.About,
				 city=findUser.CityCounty,
				 status=findUser.Status,
				 Instagram=findUser.InstagramUrl,
				 Linkedin=findUser.LinkedinUrl,
				 Twitter=findUser.TwitterUrl
			};
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Index(UpdateUserDTO model)
		{
			if (ModelState.IsValid)
			{
			 //kullanıcı isterse şifreyi girmesse ne olacak onada daha sonra bakalım
				var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
				if (model.picture != null)
				{
					var source = Directory.GetCurrentDirectory();
					var extension = Path.GetExtension(model.picture.FileName);
					var newImageName = Guid.NewGuid() + extension;
					var saveLocation = source + "/wwwroot/imgfile/" + newImageName;
					var stream = new FileStream(saveLocation, FileMode.Create);
					await model.picture.CopyToAsync(stream);
					findUser.ProfileImage = "/imgfile/" + newImageName;
                }
                findUser.Status  = model.status;
                findUser.Surname = model.surname;
                findUser.PhoneNumber = model.phoneNumber;
                findUser.UserName = model.userName;
                findUser.Name = model.name;
                findUser.TwitterUrl  = model.Twitter;
                findUser.InstagramUrl  = model.Instagram;
                findUser.LinkedinUrl = model.Linkedin;
                findUser.Email  = model.mail;
                findUser.About = model.about;
                findUser.CityCounty  = model.city;
				//şifreyi aşağıdaki işlemle güncelliyoruz
				findUser.PasswordHash = _userManager.PasswordHasher.HashPassword(findUser, model.password);
				var result = await _userManager.UpdateAsync(findUser);
				if (result.Succeeded)
				{
					await _signInManager.SignOutAsync();
					return RedirectToAction("Index","Login");
				}
				else
				{
					foreach(var x in result.Errors)
					{
						ModelState.AddModelError(x.Code, x.Description);
					}
				}
			}
			return View();
		}
	}
}
