using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.MealDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace RecipesProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class SuggestRecipeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMealService _mealService;
        private readonly ICategoryService _categoryService;

        public SuggestRecipeController(IMapper mapper, IMealService mealService, ICategoryService categoryService)
        {
            _mapper = mapper;
            _mealService = mealService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<MealListDTO>>(_mealService.TGetListAll(c => c.DeleteStatus == true && c.RecipeStatus == false));
            return View(values);
        }
        public IActionResult ConfirmedMeal(int id)
        {
            var findMeal=_mealService.TGetById(id);
            findMeal.DeleteStatus = true;
            findMeal.RecipeStatus= true;
            _mealService.TUpdate(findMeal);
            return RedirectToAction("Index","MealRecipes");
        }
        public IActionResult DeleteMeal(int id)
        {
            var findMeal = _mealService.TGetById(id);
            findMeal.DeleteStatus = false;
            findMeal.RecipeStatus = false;
            _mealService.TUpdate(findMeal);
            return RedirectToAction("Index", "MealRecipes");
        }
        [HttpGet]
        public IActionResult MealDetails(int id)
        {
            IEnumerable<SelectListItem> categoryies = (from x in _categoryService.TGetListAll(x => x.DeleteStatus == true)
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId.ToString()
                                                       }
                                                   ).ToList();

            TempData["dropdownC"] = categoryies;
            var findMeal = _mapper.Map<UpdateMealDTO>(_mealService.TGetById(id));
            return View(findMeal);
        }
    }
}
