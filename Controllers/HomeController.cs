using System;
using Microsoft.AspNetCore.Mvc;
namespace LearnAspNetCoreMvc.Controllers{
    public class HomeController:Controller{
        public String index(){
            return "Hello from Home Controller";
        }
    }
}