using DTOLayer.DTOs.VisitorApiDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RecipesProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class VisitorApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        //eklemelerde,güncellemelerde,silmede serializeObject kullanılır.
        //Listeleme veya bulma işlemlerinde DeserializeObject kullanılır.

        public VisitorApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //http://localhost:1393/api/Visitors
        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:1393/api/Visitors");
            //url'deki bulunan apiye istek gönderdim
            if (responseMessage.IsSuccessStatusCode)//eğer istek başarılıysa
            {
                //api'lerimde verilerin içeriğinin okunup jsonData'ya atmasını söyledim
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var getVisitors = JsonConvert.DeserializeObject<List<GetListVisitorDTO>>(jsonData);
                return View(getVisitors);
               
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddVisitor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddVisitor(AddVisitorDTO model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:1393/api/Visitors",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:1393/api/Visitors/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> VisitorDetails(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:1393/api/Visitors/{id}");
            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var getVisitorById = JsonConvert.DeserializeObject<UpdateVisitorDTO>(jsonData);
                return View(getVisitorById);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> VisitorDetails(UpdateVisitorDTO model)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(model);
            StringContent stringContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync($"http://localhost:1393/api/Visitors/{model.VisitorId}",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
