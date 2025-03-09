using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.MealDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;

namespace RecipesProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class MealRecipesController : Controller
    {
        private readonly IMealService _mealService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public MealRecipesController(IMealService mealService, IMapper mapper, ICategoryService categoryService)
        {
            _mealService = mealService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<MealListDTO>>(_mealService.TGetListAll(x=>x.DeleteStatus==true&&x.RecipeStatus==true));
            return View(values);
        }
        [HttpGet]
        public IActionResult AddMeal()
        {   //list<>
            List<SelectListItem> CategoryList = (from x in _categoryService.TGetListAll(x=>x.DeleteStatus==true)
                                                 select new SelectListItem
                                                 {
                                                     Value=x.CategoryId.ToString(),
                                                     Text=x.CategoryName
                                                 }).ToList();
            ViewData["dc"] = CategoryList;                                    
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddMeal(InsertMealDTO model)
        {
            //Resim ekleme işlemi
            if (model.Image != null)//resim seçiliyse
            {
                var source = Directory.GetCurrentDirectory();//seçili resmin aktif yolunu al
                var extension = Path.GetExtension(model.Image.FileName);//dosyanın uzantısını al
                var imageName = Guid.NewGuid() + extension;//rastgele bir dosya ismi ata ve uzantıyla birlikte al
                var saveLocation = source + "/wwwroot/imgfile/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);//dosyanın nereye kaydedileceği işlemini tutar
                await model.Image.CopyToAsync(stream);
                if (ModelState.IsValid)
                {
                    _mealService.TAdd(new Meal
                    {
                        CategoryId = model.CategoryId,
                        DeleteStatus = true,
                        LongDescription = model.LongDescription,
                        MainHeader = model.MainHeader,
                        MealImage= "/imgfile/" + imageName,
                        MealName=model.MealName,
                        ShortDescription=model.ShortDescription
                    });
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        public IActionResult DeleteMeal(int id)
        {
            var findMeal=_mealService.TGetById(id);
            findMeal.DeleteStatus = false;
            _mealService.TUpdate(findMeal);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditMeal(int id)
        {
            List<SelectListItem> CategoryList = (from x in _categoryService.TGetListAll(x => x.DeleteStatus == true)
                                                        select new SelectListItem
                                                        {
                                                            Value = x.CategoryId.ToString(),
                                                            Text = x.CategoryName
                                                        }
                                                     ).ToList();

            ViewData["dc"] = CategoryList;
            var findMeal = _mapper.Map<UpdateMealDTO>(_mealService.TGetById(id));
            return View(findMeal);
        }
        [HttpPost]
        public async Task<IActionResult> EditMeal(UpdateMealDTO model)
        {
            if (model.Image != null)//foto seçiliyse
            {
                var source = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = source + "/wwwroot/imgfile/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await model.Image.CopyToAsync(stream);
                if (ModelState.IsValid)
                {
                    _mealService.TUpdate(new Meal
                    {
                        CategoryId = model.CategoryId,
                        DeleteStatus = true,
                        ShortDescription = model.ShortDescription,
                        LongDescription = model.LongDescription,
                        MainHeader = model.MainHeader,
                        MealId = model.MealId,
                        MealName = model.MealName,
                        MealImage = "/imgfile/" + imageName
                    });
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}
