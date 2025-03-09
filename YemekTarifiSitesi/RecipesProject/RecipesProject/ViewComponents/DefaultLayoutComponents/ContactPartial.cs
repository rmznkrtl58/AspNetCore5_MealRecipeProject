using Microsoft.AspNetCore.Mvc;

namespace RecipesProject.ViewComponents.DefaultLayoutComponents
{
    public class ContactPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
