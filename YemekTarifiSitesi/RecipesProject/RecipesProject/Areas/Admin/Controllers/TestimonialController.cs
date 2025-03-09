using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.TestimonialDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RecipesProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<TestimonialListDto>>(_testimonialService.TGetListAll(x => x.DeleteStatus == true));
            return View(values);
        }
        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTestimonial(AddTestimonialDTO model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    var source = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(model.ImageFile.FileName);
                    var imageName = Guid.NewGuid() + extension;
                    var saveLocation = source + "/wwwroot/imgfile/" + imageName;
                    var stream = new FileStream(saveLocation, FileMode.Create);
                    await model.ImageFile.CopyToAsync(stream);
                    _testimonialService.TAdd(new Testimonial
                    {
                        DeleteStatus = true,
                        Image= "/imgfile/" + imageName,
                        Message=model.Message,
                        NameSurname=model.NameSurname,
                        Status=model.Status,
                    });
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult EditTestimonial(int id)
        {
            var findTestimonial = _mapper.Map<UpdateTestimonialDTO>(_testimonialService.TGetById(id));
            return View(findTestimonial);
        }
        [HttpPost]
        public async Task<IActionResult> EditTestimonial(UpdateTestimonialDTO model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    var source = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(model.ImageFile.FileName);
                    var imageName = Guid.NewGuid() + extension;
                    var saveLocation = source + "/wwwroot/imgfile/" + imageName;
                    var stream = new FileStream(saveLocation, FileMode.Create);
                    await model.ImageFile.CopyToAsync(stream);
                    _testimonialService.TUpdate(new Testimonial
                    {
                        TestimonialId = model.TestimonialId,
                        DeleteStatus = true,
                        Image = "/imgfile/" + imageName,
                        Message = model.Message,
                        NameSurname = model.NameSurname,
                        Status = model.Status,
                    });
                    return RedirectToAction("Index");

                }
            }
            return View(model);
        }
        public IActionResult DeleteTestimonial(int id)
        {
            var findTestimonial=_testimonialService.TGetById(id);
            findTestimonial.DeleteStatus=false;
            _testimonialService.TUpdate(findTestimonial);
            return RedirectToAction("Index");
        }
    }
}
