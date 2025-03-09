using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.AboutDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class DefaultController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public DefaultController(IAboutService aboutService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _aboutService = aboutService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //listeleme ve findlama işleminde _mapper.map kullanıyoz.
            ViewBag.k1 = "Hakkımızda Sayfası:";
                            //hedef                      //Kaynak
            var findAbout = _mapper.Map<AboutUpdateDTO>(_aboutService.TGetById(1));
            return View(findAbout);
        }
        [HttpPost]
        public IActionResult Index(AboutUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                _aboutService.TUpdate(new About
                {
                    Description= model.Description,
                    Image= model.Image,
                    Item1=model.Item1,
                    Item2=model.Item2,
                    Item3 = model.Item3,
                    SubHeader=model.SubHeader,
                    TopHeader=model.TopHeader,
                    AboutId=model.AboutId
                });
                return RedirectToAction("Index", "Default");
            }
            else
            {
                return View(model);
            }
        }
      

    }
}
