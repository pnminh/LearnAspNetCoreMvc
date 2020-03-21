using Microsoft.AspNetCore.Mvc;

namespace LearnAspNetCoreMvc.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        [HttpGet]
        public IActionResult index()
        {
            return View();
        }
        [Route("long_year/{year:min(1980)}/{month:range(1,12)}/{date:range(1,31)}")]
        public IActionResult LongYear(int year, int month, int date)
        {
            return new ContentResult { Content = string.Format("Year: {0}, Month: {1}, Day: {2}", year, month, date) };

        }

    }
}