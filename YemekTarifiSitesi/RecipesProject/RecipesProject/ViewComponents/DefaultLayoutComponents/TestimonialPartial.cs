using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.TestimonialDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RecipesProject.ViewComponents.DefaultLayoutComponents
{
    public class TestimonialPartial:ViewComponent
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _Mapper;

        public TestimonialPartial(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _Mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var values = _Mapper.Map<List<TestimonialListDto>>(_testimonialService.TGetListAll(x=>x.DeleteStatus==true));
            return View(values);
        }
    }
}
