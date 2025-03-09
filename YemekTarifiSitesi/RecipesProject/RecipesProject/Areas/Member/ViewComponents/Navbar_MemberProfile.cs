using AutoMapper;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesProject.Areas.Member.ViewComponents
{
    public class Navbar_MemberProfile:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public Navbar_MemberProfile(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            int id = findUser.Id;
            TempData["userName"] = _userManager.Users.Where(x => x.Id == id).Select(x => x.Name).FirstOrDefault();
            TempData["userSurname"] = _userManager.Users.Where(x => x.Id == id).Select(x => x.Surname).FirstOrDefault();
            TempData["userStatus"] = _userManager.Users.Where(x => x.Id == id).Select(x => x.Status).FirstOrDefault();
            TempData["userImage"] = _userManager.Users.Where(x => x.Id == id).Select(x => x.ProfileImage).FirstOrDefault();
            return View();
        }
    }
}
