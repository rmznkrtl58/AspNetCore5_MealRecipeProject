using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.MealDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RecipesProject.ViewComponents.DefaultLayoutComponents
{
    public class MealsPartial:ViewComponent
    {
        private readonly IMealService _mealService;
        private readonly IMapper _mapper;

        public MealsPartial(IMealService mealService, IMapper mapper)
        {
            _mealService = mealService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {                         //hedef             //kaynak
           var values= _mapper.Map<List<MealListDTO>>(_mealService.TGetListMealWithCategory(x=>x.DeleteStatus==true&&x.RecipeStatus==true));
            return View(values);
        }
    }
}
