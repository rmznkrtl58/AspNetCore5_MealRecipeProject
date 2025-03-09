using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.EventDTOs;
using DTOLayer.DTOs.MessageDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesProject.Areas.Member.ViewComponents
{
    public class Navbar_MemberEventNotification:ViewComponent
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public Navbar_MemberEventNotification(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        public  IViewComponentResult Invoke()
        {
            var values = _mapper.Map<List<EventListDTO>>(_eventService.TGetListAll(x => x.DeleteStatus == true));
            return View(values);
        }
    }
}
