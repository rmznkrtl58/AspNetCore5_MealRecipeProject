using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.WhyUsDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RecipesProject.ViewComponents.DefaultLayoutComponents
{
    public class WhyUsPartial:ViewComponent
    {
        private readonly IWhyUsService _whyUsService;
        private readonly IMapper _mapper;
        public WhyUsPartial(IWhyUsService whyUsService, IMapper mapper)
        {
            _whyUsService = whyUsService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {                        //Hedef                //Yol
            var values = _mapper.Map<List<WhyUsListDTO>>(_whyUsService.TGetListAll());
            return View(values);
        }
    }
}
