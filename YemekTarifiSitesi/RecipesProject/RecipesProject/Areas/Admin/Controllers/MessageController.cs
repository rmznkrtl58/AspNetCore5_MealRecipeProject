using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.MessageDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(UserManager<AppUser> userManager, IMessageService messageService, IMapper mapper)
        {
            _userManager = userManager;
            _messageService = messageService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            //Sisteme authentice olan kullanıcının Id değerine göre mesajları getir
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            int id = findUser.Id;
            var values = _mapper.Map<List<ListMessageDTO>>(_messageService.TGetListMessageBySenderUser(x => x.ReceiverId == id && x.DeleteStatus == true));
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> MessagesSend()
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            int id= findUser.Id;
            var values = _mapper.Map<List<ListMessageDTO>>(_messageService.TGetListMessageByReceiverUser(x=>x.SenderId==id&&x.DeleteStatus==true));
            return View(values);
        }
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var findMessage = _mapper.Map<MessageDetailsDTO>(_messageService.TGetMessageBySenderUser(id));
            return View(findMessage);
        }
        [HttpGet]
        public IActionResult SenderMessageDetails(int id)
        {
            var findMessage = _mapper.Map<MessageDetailsDTO>(_messageService.TGetMessageByReceiverUser(id));
            return View(findMessage);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            IEnumerable<SelectListItem> userList = (from x in _userManager.Users.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Value = x.Id.ToString(),
                                                        Text= x.Name+" "+x.Surname+" "+$"({x.Status})"
                                                    }).ToList();
            ViewBag.ud = userList;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageDTO model)
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var id = findUser.Id;
            _messageService.TAdd(new Message
            {
                Content = model.Content,
                SenderId = id,
                DeleteStatus = true,
                MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                ReceiverId=model.ReceiverId,
                Subject=model.Subject
            });
            return RedirectToAction("MessagesSend");
        }
        public IActionResult DeleteMessage(int id)
        {
            var findMessage = _messageService.TGetById(id);
            findMessage.DeleteStatus = false;
            _messageService.TUpdate(findMessage);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
