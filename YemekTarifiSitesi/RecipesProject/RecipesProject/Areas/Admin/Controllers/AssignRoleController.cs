using DTOLayer.DTOs.RoleDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles ="Admin")]
    public class AssignRoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AssignRoleController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AssignUserRole(int id)
        {
            var findUser = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["userID"] = findUser.Id;
            var roles= _roleManager.Roles.ToList();
            //bulduğumuz kullanıcı hangi rollere sahip?
            var userRoles = await _userManager.GetRolesAsync(findUser);
            List<AssignUserRoleDTO>assignRoleModels=new List<AssignUserRoleDTO>();
            foreach(var x in roles)
            {
                //Role tablomun içerisinden Rollerimi çekiyor.
                AssignUserRoleDTO model=new AssignUserRoleDTO();
                model.RoleId= x.Id;
                model.RoleName= x.Name;
                //bool türündeki roleExist propum ne demek istiyor?
                //Bulduğum kullanıcının atanan rolleri içinden role
                //tablomdaki roller eşleşiyorsa model.RoleExist true dönsün
                model.RoleExist = userRoles.Contains(x.Name);
                assignRoleModels.Add(model);
            }
            return View (assignRoleModels);
        }
        [HttpPost]
        public async Task<IActionResult> AssignUserRole(List<AssignUserRoleDTO> models)
        {
            var userId = (int)TempData["userID"];
            var findUser = _userManager.Users.FirstOrDefault(x=>x.Id==userId);
            foreach (var x in models)//modelimdeki
            {
                if (x.RoleExist)
                {
                    await _userManager.AddToRoleAsync(findUser,x.RoleName); 
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(findUser, x.RoleName);
                }
            } 
            return RedirectToAction("Index");
        }
    }
}
