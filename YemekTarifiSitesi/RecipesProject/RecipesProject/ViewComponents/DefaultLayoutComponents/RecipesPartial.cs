using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.MealDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using X.PagedList.Extensions;

namespace RecipesProject.ViewComponents.DefaultLayoutComponents
{
    public class RecipesPartial:ViewComponent
    {
        private readonly IMealService _mealService;
        private readonly IMapper _mapper;

        public RecipesPartial(IMealService mealService, IMapper mapper)
        {
            _mealService = mealService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(int page=1)
        {                                 //hedef            //kaynak
            var values = _mapper.Map<List<MealListDTO>>(_mealService.TGetListMealWithCategory(x=>x.DeleteStatus==true&&x.RecipeStatus==true));
            var valuesPager= values.ToPagedList(page,4);//1.p->sayfa kaçtan başlasın
            //2.p->sayfada kaç veri listelensin
            //versiyonda bir sorun var bakılacak ilerde
            return View(values);
        }
    }
}
