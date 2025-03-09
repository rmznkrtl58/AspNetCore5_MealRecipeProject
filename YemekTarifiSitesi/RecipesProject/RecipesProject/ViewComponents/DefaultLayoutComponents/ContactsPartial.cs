using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.ContactDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RecipesProject.ViewComponents.DefaultLayoutComponents
{
    public class ContactsPartial:ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IContactService _contactService;

        public ContactsPartial(IMapper mapper, IContactService contactService)
        {
            _mapper = mapper;
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _mapper.Map<List<ContactListDTO>>(_contactService.TGetListAll());
            return View(values);
        }
    }
}
