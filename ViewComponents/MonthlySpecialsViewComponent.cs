using LearnAspNetCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnAspNetCoreMvc.ViewComponents
{
    [ViewComponent]
    public class MonthlySpecialsViewComponent:ViewComponent
    {
        private readonly SpecialDataContext _specialDataContext;
        public MonthlySpecialsViewComponent(SpecialDataContext specialDataContext){
            this._specialDataContext = specialDataContext;
        }
        public IViewComponentResult Invoke(){
            return View(_specialDataContext.GetSpecials());
        }
    }
}