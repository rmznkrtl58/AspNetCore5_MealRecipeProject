using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.EventDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace RecipesProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<EventListDTO>>(_eventService.TGetListAll());
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEvent()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEvent(InsertEventDTO model)
        {
            if (model.ImageFile != null)//resim seçiliyse
            {
                var source=Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.ImageFile.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = source + "/wwwroot/imgfile/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await model.ImageFile.CopyToAsync(stream);
                if (ModelState.IsValid)
                {
                    _eventService.TAdd(new Event
                    {
                        DeleteStatus = true,
                        Image = "/imgfile/" + imageName,
                        Item1 = model.Item1,
                        Item2 = model.Item2,
                        Item3 = model.Item3,
                        MainHeader = model.MainHeader,
                        Price = model.Price,
                        SubDescription = model.SubDescription
                    });
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult EditEvent(int id)
        {
            var findEvent = _mapper.Map<UpdateEventDTO>(_eventService.TGetById(id));
            return View(findEvent);
        }
        [HttpPost]
        public async Task<IActionResult> EditEvent(UpdateEventDTO model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)//resim seçiliyse
                {
                    var source=Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(model.ImageFile.FileName);
                    var imageName = Guid.NewGuid() + extension;
                    var saveLocation = source + "/wwwroot/imgfile/" + imageName;
                    var stream = new FileStream(saveLocation, FileMode.Create);
                    await model.ImageFile.CopyToAsync(stream);
                    _eventService.TUpdate(new Event
                    {
                        DeleteStatus = true,
                        EventId=model.EventId,
                        Image= "/imgfile/" + imageName,
                        Item1=model.Item1,
                        Item2=model.Item2,
                        Item3 = model.Item3,
                        MainHeader=model.MainHeader,
                        Price=model.Price,
                        SubDescription=model.SubDescription
                    });
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        public IActionResult DeleteEvent(int id)
        {
            var findEvent=_eventService.TGetById(id);
            findEvent.DeleteStatus= false;
            _eventService.TUpdate(findEvent);
            return RedirectToAction("Index");
        }
    }
}
