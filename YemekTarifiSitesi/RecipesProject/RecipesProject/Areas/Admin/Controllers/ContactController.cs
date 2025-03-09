using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.ContactUsDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RecipesProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class ContactController : Controller
    {
       
        private readonly IContactUsService _contactUsService;
        private readonly IMapper _mapper;

        public ContactController(IContactUsService contactUsDal, IMapper mapper)
        {
            _contactUsService = contactUsDal;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<ListContactUsDTO>>(_contactUsService.TGetListAll());
            return View(values);
        }
        public IActionResult ContactUsDetails(int id)
        {
            var value = _mapper.Map<ListContactUsDTO>(_contactUsService.TGetById(id));
            return View(value);
        }
    }
}
