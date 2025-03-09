using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.EventDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RecipesProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]/{id?}")]
    public class EventController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEventService _eventService;

        public EventController(IMapper mapper, IEventService eventService)
        {
            _mapper = mapper;
            _eventService = eventService;
        }

        public IActionResult Index()
        {
            ViewBag.t2 = "Etkinlikler";
            ViewBag.t3 = "Duyurular";
            var values = _mapper.Map<List<EventListDTO>>(_eventService.TGetListAll(x => x.DeleteStatus == true));
            return View(values);
        }
        public IActionResult EventDetails(int id)
        {
            ViewBag.t2 = "Etkinlikler";
            ViewBag.t3 = "Duyuru İçeriği";
            var values = _mapper.Map<UpdateEventDTO>(_eventService.TGetById(id));
            return View(values);
        }
    }
}
