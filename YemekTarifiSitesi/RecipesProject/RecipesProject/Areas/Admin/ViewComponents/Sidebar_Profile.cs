using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesProject.Areas.Admin.ViewComponents
{
    public class Sidebar_Profile:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public Sidebar_Profile(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            int userId = findUser.Id;
            TempData["userImage"] = _userManager.Users.Where(x => x.Id == userId).Select(x => x.ProfileImage).FirstOrDefault();
            TempData["userName"] = _userManager.Users.Where(x => x.Id == userId).Select(x => x.Name).FirstOrDefault();
            TempData["userSurname"] = _userManager.Users.Where(x => x.Id == userId).Select(x => x.Surname).FirstOrDefault();
            TempData["userStatus"] = _userManager.Users.Where(x => x.Id == userId).Select(x => x.Status).FirstOrDefault();

            return View();
        }
    }
}
