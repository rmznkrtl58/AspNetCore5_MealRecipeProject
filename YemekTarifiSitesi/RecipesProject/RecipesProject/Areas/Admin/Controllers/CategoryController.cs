using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EntityLayer.Concrete;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Authorization;

namespace RecipesProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<CategoryListDTO>>(_categoryService.TGetListAll(x=>x.DeleteStatus==true));
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(AddCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                _categoryService.TAdd(new Category
                {
                    CategoryName = model.CategoryName,
                    DeleteStatus = true
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var values = _mapper.Map<UpdateCategoryDTO>(_categoryService.TGetById(id));
            return View (values);
        }
        [HttpPost]
        public IActionResult EditCategory(UpdateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                _categoryService.TUpdate(new Category
                {
                    CategoryId = model.CategoryId,
                    CategoryName = model.CategoryName,
                    DeleteStatus = true
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult DeleteCategory(int id)
        {
            var findCategory=_categoryService.TGetById(id);
            findCategory.DeleteStatus= false;
            _categoryService.TUpdate(findCategory);
            return RedirectToAction("Index");
        }
    }
}
