using AutoMapper;
using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DTOLayer.DTOs.MealDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]/{id?}")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMealService _mealService;
        private readonly IMapper _mapper;

        public DashboardController(UserManager<AppUser> userManager, IMealService mealService, IMapper mapper)
        {
            _userManager = userManager;
            _mealService = mealService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            int userId = findUser.Id;
            var values = _mapper.Map<List<MealListDTO>>(_mealService.TGetListMealWithCategory(x=>x.DeleteStatus==true&&x.AppUserId==userId));
            //aşağıda solidi ezdim ilerde bakacağım
            using (var ent=new Context())
            {
                ViewBag.c1 = ent.Meals.Where(x => x.AppUserId == userId && x.RecipeStatus == true).Count();
                ViewBag.c2 = ent.Meals.Where(x => x.AppUserId == userId && x.RecipeStatus == false).Count();
                ViewBag.c3 = ent.Messages.Where(x => x.ReceiverId == userId && x.DeleteStatus == true).Count();
            }
            ViewBag.t2 = "İstatistikler";
            ViewBag.t3 = "Dashboard";
            return View(values);
        }
    }
}
