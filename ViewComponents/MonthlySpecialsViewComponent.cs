using Microsoft.AspNetCore.Mvc;

namespace LearnAspNetCoreMvc.ViewComponents
{
    [ViewComponent]
    public class MonthlySpecialsViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(){
            return View();
        }
    }
}