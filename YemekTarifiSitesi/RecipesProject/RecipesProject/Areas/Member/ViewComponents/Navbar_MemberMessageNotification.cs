using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.MessageDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesProject.Areas.Member.ViewComponents
{
    public class Navbar_MemberMessageNotification:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public Navbar_MemberMessageNotification(UserManager<AppUser> userManager, IMessageService messageService, IMapper mapper)
        {
            _userManager = userManager;
            _messageService = messageService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            int id = findUser.Id;
            var values = _mapper.Map<List<ListMessageDTO>>(_messageService.TGetListMessageBySenderUser(x => x.ReceiverId == id));
            return View(values);
        }
    }
}
