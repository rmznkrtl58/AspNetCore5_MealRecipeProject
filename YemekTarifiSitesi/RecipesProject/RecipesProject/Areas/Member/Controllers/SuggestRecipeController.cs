using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.MealDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]/{id?}")]
    public class SuggestRecipeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IMealService _mealService;
        private readonly ICategoryService _categoryService;

        public SuggestRecipeController(UserManager<AppUser> userManager, IMapper mapper, IMealService mealService, ICategoryService categoryService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _mealService = mealService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.t2 = "Tarifler";
            ViewBag.t3 = "Onaylanan Tarifler";
            //Onaylanan tariflerimizin görüntülendiği yer
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            int id = findUser.Id;
            var values = _mapper.Map<List<MealListDTO>>(_mealService.TGetListMealWithCategory(x => x.DeleteStatus == true && x.AppUserId == id && x.RecipeStatus == true));
            return View(values);
        }
        public async Task<IActionResult> UnConfirmedRecipes()
        {
            ViewBag.t2 = "Tarifler";
            ViewBag.t3 = "Onaylanmayan Tarifler";
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            int id = findUser.Id;
            var values = _mapper.Map<List<MealListDTO>>(_mealService.TGetListMealWithCategory(x => x.DeleteStatus == true && x.AppUserId == id && x.RecipeStatus == false));
            return View(values);
        }
        [HttpGet]
        public IActionResult AddRecipe()
        {
            ViewBag.t2 = "Tarifler";
            ViewBag.t3 = "Yeni Tarif";
            IEnumerable<SelectListItem> categoryies = (from x in _categoryService.TGetListAll(x => x.DeleteStatus == true)
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId.ToString()
                                                       }
                                                    ).ToList();

            TempData["dropdownC"] = categoryies;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRecipe(InsertMealDTO model)
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var id = findUser.Id;
            if (ModelState.IsValid)
            {
                if (model.Image != null)//resim seçiliyse
                {
                    string source = Directory.GetCurrentDirectory();
                    string extension = Path.GetExtension(model.Image.FileName);
                    string newFileName = Guid.NewGuid() + extension;
                    string saveLocation = source + "/wwwroot/imgfile/" + newFileName;
                    var stream = new FileStream(saveLocation, FileMode.Create);
                    await model.Image.CopyToAsync(stream);
                    _mealService.TAdd(new Meal
                    {

                        AppUserId = id,
                        ShortDescription = model.ShortDescription,
                        RecipeStatus = false,
                        DeleteStatus = true,
                        MealName = model.MealName,
                        MealImage = "/imgfile/" + newFileName,
                        CategoryId = model.CategoryId,
                        LongDescription = model.LongDescription,
                        MainHeader = model.MainHeader,
                    });
                    return RedirectToAction("UnConfirmedRecipes");
                }
            }
            else
            {
                return View(model);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult MealDetails(int id)
        {
            ViewBag.t2 = "Tarifler";
            ViewBag.t3 = "Tarif İçeriği";
            IEnumerable<SelectListItem> categoryies = (from x in _categoryService.TGetListAll(x => x.DeleteStatus == true)
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId.ToString()
                                                       }
                                                    ).ToList();

            TempData["dropdownC"] = categoryies;
            var values = _mapper.Map<UpdateMealDTO>(_mealService.TGetById(id));
            return View(values);
        }
        [HttpGet]
        public IActionResult MealRecipeDetails(int id)
        {
            ViewBag.t2 = "Tarifler";
            ViewBag.t3 = "Tarif İçeriği";
            IEnumerable<SelectListItem> categoryies = (from x in _categoryService.TGetListAll(x => x.DeleteStatus == true)
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId.ToString()
                                                       }
                                                    ).ToList();

            TempData["dropdownC"] = categoryies;
            var values = _mapper.Map<UpdateMealDTO>(_mealService.TGetById(id));
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> MealRecipeDetails(UpdateMealDTO model)
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var id = findUser.Id;
            if (ModelState.IsValid)
            {
                if (model.Image != null)//resim seçiliyse
                {
                    string source = Directory.GetCurrentDirectory();
                    string extension = Path.GetExtension(model.Image.FileName);
                    string newFileName = Guid.NewGuid() + extension;
                    string saveLocation = source + "/wwwroot/imgfile/" + newFileName;
                    var stream = new FileStream(saveLocation, FileMode.Create);
                    await model.Image.CopyToAsync(stream);
                    _mealService.TUpdate(new Meal
                    {
                        MealId= model.MealId,
                        AppUserId = id,
                        ShortDescription = model.ShortDescription,
                        RecipeStatus = false,
                        DeleteStatus = true,
                        MealName = model.MealName,
                        MealImage = "/imgfile/" + newFileName,
                        CategoryId = model.CategoryId,
                        LongDescription = model.LongDescription,
                        MainHeader = model.MainHeader,
                    });
                    return RedirectToAction("UnConfirmedRecipes");
                }
                return View(model);
            }
            return View(model);
        }
    }
}
