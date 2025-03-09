using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.WhyUsDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RecipesProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class WhyUsController : Controller
    {
        private readonly IWhyUsService _whyUsService;
        private readonly IMapper _mapper;
        public WhyUsController(IWhyUsService whyUsService, IMapper mapper)
        {
            _whyUsService = whyUsService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.k1 = "Biz Kimiz Sayfası:";
            var values = _mapper.Map<List<WhyUsListDTO>>(_whyUsService.TGetListAll());
            return View(values);
        }
        [HttpGet]
        public IActionResult EditWhyUs(int id)
        {
            ViewBag.k1 = "Biz Kimiz Sayfası:";
            var findWhyUs = _mapper.Map<WhyUsUpdateDTO>(_whyUsService.TGetById(id));
            return View(findWhyUs);
        }
        [HttpPost]
        public IActionResult EditWhyUs(WhyUsUpdateDTO model)
        {

            if (ModelState.IsValid)
            {
                _whyUsService.TUpdate(new WhyUs
                {
                    Description = model.Description,
                    MainHeader = model.MainHeader,
                    WhyUsId=model.WhyUsId
                });
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult AddWhyUs()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddWhyUs(WhyUsInsertDTO model)
        {
            if (ModelState.IsValid)
            {
                _whyUsService.TAdd(new WhyUs
                {
                    Description = model.Description,
                    MainHeader = model.MainHeader
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
