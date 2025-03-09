using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.MealDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RecipesProject.ViewComponents.DefaultLayoutComponents
{
    public class GalleryPartial:ViewComponent
    {
        private readonly IMealService _mealService;
        private readonly IMapper _mapper;

        public GalleryPartial(IMealService mealService, IMapper mapper)
        {
            _mealService = mealService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {                            //hedef            //kaynak
            var values = _mapper.Map<List<MealImageListDTO>>(_mealService.TGetListLast8Meal());
            return View(values);
        }
    }
}
