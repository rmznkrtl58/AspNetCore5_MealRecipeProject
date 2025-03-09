using DTOLayer.DTOs.UserDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RecipesProject.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;


        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(SignInUserDTO model)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(model.userName, model.password, false, true);
				if (result.Succeeded)
				{
					if (User.IsInRole("Admin"))
					{
                        return RedirectToAction("Index", "Default", new { area = "Admin" });
                    }
					else
					{
                        return RedirectToAction("Index", "Default", new { area = "Member" });
                    }
                }
				else
				{
					return View();
				}
			}
			return View();
		}
		public async Task<IActionResult> LogOut()
		{
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default",new {area=""});
        }
	}
}
