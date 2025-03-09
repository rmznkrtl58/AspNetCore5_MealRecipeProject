using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.MessageDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesProject.Areas.Admin.ViewComponents
{
    public class Navbar_MessagesNotification:ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public Navbar_MessagesNotification(IMessageService messageService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            int id=findUser.Id;
            var messageList = _mapper.Map<List<ListMessageDTO>>(_messageService.TGetListMessageBySenderUser(x => x.ReceiverId == id));
            return View(messageList);
        }
    }
}
