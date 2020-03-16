using Microsoft.AspNetCore.Mvc;

namespace LearnAspNetCoreMvc.Controllers{
    public class BlogController:Controller{
        public IActionResult index(){
            return new ContentResult{Content="From BlogController with love"};
        }
    }
}