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

namespace RecipesProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]/{id?}")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(IMessageService messageService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.t2 = "Mesaj";
            ViewBag.t3 = "Gelen Kutusu";
            var findUser =await _userManager.FindByNameAsync(User.Identity.Name);
            int userId = findUser.Id;
            var values = _mapper.Map<List<ListMessageDTO>>(_messageService.TGetListMessageBySenderUser(x => x.ReceiverId == userId && x.DeleteStatus == true));
            return View(values);
        }
        public async Task<IActionResult> MessagesSend()
        {
            ViewBag.t2 = "Mesaj";
            ViewBag.t3 = "Giden Kutusu";
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            int userId = findUser.Id;
            var values = _mapper.Map<List<ListMessageDTO>>(_messageService.TGetListMessageByReceiverUser(z => z.SenderId == userId&&z.DeleteStatus==true));
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            ViewBag.t2 = "Mesaj";
            ViewBag.t3 = "Mesaj Detayı";
            var findMessage = _mapper.Map<MessageDetailsDTO>(_messageService.TGetMessageBySenderUser(id));
            return View(findMessage);
        }
        public IActionResult ReceiverMessageDetails(int id)
        {
            ViewBag.t2 = "Mesaj";
            ViewBag.t3 = "Mesaj Detayı";
            var findMessage = _mapper.Map<MessageDetailsDTO>(_messageService.TGetMessageByReceiverUser(id));
            return View(findMessage); 
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            ViewBag.t2 = "Mesaj";
            ViewBag.t3 = "Yeni Mesaj";
            IEnumerable<SelectListItem> userList = (from x in _userManager.Users.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Value=x.Id.ToString(),
                                                        Text=x.Name+" "+x.Surname+" "+$"({x.Status})"
                                                    }).ToList();
            ViewBag.du = userList;
            return View();
        }
        public async Task<IActionResult> SendMessage(SendMessageDTO model)
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            int id = findUser.Id;
            _messageService.TAdd(new Message
            {
                Content = model.Content,
                SenderId = id,
                ReceiverId = model.ReceiverId,
                DeleteStatus = true,
                MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Subject = model.Subject,
            });
            return RedirectToAction("MessagesSend");
        }
        public IActionResult DeleteMessage(int id)
        {
            var findMessage = _messageService.TGetById(id);
            findMessage.DeleteStatus = false;
            _messageService.TUpdate(findMessage);
            return RedirectToAction("Index","Dashboard");
        }
    }
}
