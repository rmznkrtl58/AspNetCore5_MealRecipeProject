using Microsoft.AspNetCore.Mvc;

namespace RecipesProject.ViewComponents.DefaultLayoutComponents
{
    public class SuggestRecipePartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
