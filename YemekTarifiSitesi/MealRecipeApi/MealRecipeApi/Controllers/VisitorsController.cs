using MealRecipeApi.DataAccessLayer.Concrete;
using MealRecipeApi.EntityLayer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MealRecipeApi.Controllers
{
    [EnableCors]//startup kullanımında cors yapılandırmasını yapmıştım buradada kullanıyorum
    [Route("api/[controller]")]
    [ApiController]
    //aşağıya yazacağım işlemler solide aykırı olabilir ilerde düzenleme yapabilirim.
    //apilerimi yazdıktan sonra diğer projemdeki ui'dan bu verilerimi consume
    //edeceğim.
    public class VisitorsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetListVisitors()
        {
            //Apilerde Listeleme
            using (var ent=new Context())
            {
                var values = ent.Visitors.ToList();
                return Ok(values);//ok->başarılı
            }
        }
        [HttpPost]
        public IActionResult AddVisitor(Visitor v)
        {
            using (var ent = new Context()) 
            {
                ent.Visitors.Add(v);
                ent.SaveChanges();
                return Ok();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetVisitorById(int id)
        {
            using (var ent = new Context())
            {
                var findVisitor = ent.Visitors.Find(id);
                if (findVisitor == null)
                {
                    return NotFound();//404 bulunamadı 
                }
                else
                {
                    return Ok(findVisitor);
                }
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteVisitor(int id)
        {
            using (var ent = new Context())
            {
                var findVisitor= ent.Visitors.Find(id);
                if (findVisitor == null)
                {
                    return NotFound();
                }
                else
                {
                    ent.Visitors.Remove(findVisitor);
                    ent.SaveChanges();
                    return Ok();
                }
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateVisitor(Visitor v)
        {
            using (var ent = new Context())
            {
                var findVisitor = ent.Visitors.Find(v.VisitorId);
                if (findVisitor == null)
                {
                    return NotFound();
                }
                else
                {
                    findVisitor.City= v.City;
                    findVisitor.NameSurname = v.NameSurname;
                    findVisitor.Phone = v.Phone;
                    findVisitor.Mail = v.Mail;
                    ent.Visitors.Update(findVisitor);
                    ent.SaveChanges();
                    return Ok();
                }
               
            }
           
        }
    }
}
