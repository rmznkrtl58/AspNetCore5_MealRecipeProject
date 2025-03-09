using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.AboutDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RecipesProject.ViewComponents.DefaultLayoutComponents
{
    public class AboutPartial:ViewComponent
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        public AboutPartial(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {                       //hedef               //kaynak
            var values = _mapper.Map<List<AboutListDto>>(_aboutService.TGetListAll());
            return View(values);
        }
    }
}
