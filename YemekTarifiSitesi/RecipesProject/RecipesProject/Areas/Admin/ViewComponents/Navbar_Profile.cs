using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesProject.Areas.Admin.ViewComponents
{
    public class Navbar_Profile:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public Navbar_Profile(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            int id = findUser.Id;
            TempData["userImage"] = _userManager.Users.Where(x => x.Id == id).Select(x => x.ProfileImage).FirstOrDefault();
            TempData["userName"] = _userManager.Users.Where(x => x.Id == id).Select(x => x.UserName).FirstOrDefault();
            return View();
        }
    }
}
