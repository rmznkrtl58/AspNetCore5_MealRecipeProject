using DTOLayer.DTOs.RoleDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace RecipesProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roleList = _roleManager.Roles.ToList();
            return View(roleList);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View ();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(CreateRoleDTO model)
        {
            AppRole role = new AppRole()
            {
                Name = model.roleName
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var x in result.Errors)
                {
                    ModelState.AddModelError(x.Code, x.Description);
                }
            }
            return View();
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            var findRole = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result=await _roleManager.DeleteAsync(findRole);
            if (result.Succeeded)
            {
                return RedirectToAction  ("Index");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult EditRole(int id)
        {
            var findRole = _roleManager.Roles.FirstOrDefault(y => y.Id == id);
            UpdateRoleDTO model = new UpdateRoleDTO()
            {
                Id = findRole.Id,
                Name = findRole.Name
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(UpdateRoleDTO model)
        {
            var findRole = _roleManager.Roles.FirstOrDefault(x => x.Id == model.Id);
            findRole.Name= model.Name;
            var result=await _roleManager.UpdateAsync(findRole);
            if (result.Succeeded) 
            {
                return RedirectToAction ("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}
