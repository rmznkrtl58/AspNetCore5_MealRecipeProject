using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.EventDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RecipesProject.ViewComponents.DefaultLayoutComponents
{
    public class EventsPartial:ViewComponent
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventsPartial(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = _mapper.Map<List<EventListDTO>>(_eventService.TGetListAll(x=>x.DeleteStatus==true));
            return View(values);
        }
    }
}
