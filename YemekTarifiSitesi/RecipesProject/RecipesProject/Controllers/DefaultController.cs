using BusinessLogicLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace RecipesProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IContactUsService _contactService;

        public DefaultController(IContactUsService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult ContactPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddContact(ContactUs c)
        {
            _contactService.TAdd(c);
            var values = JsonConvert.SerializeObject(c);
            return Json(values);
        }
        
    }

}
