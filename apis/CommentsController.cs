using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace LearnAspNetCoreMvc.apis
{
    [Route("api/[controller]")]
    public class CommentsController:Controller
    {
        [HttpGet]
        public IEnumerable<string> Get(){
            return new string[]{"value1", "value2"};
        }

        [HttpGet("{id}")]
        public string Get(string id){
            return "value";
        }
        [HttpPost]
        public void Post([FromBody]string value){

        }
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]string value){

        }
        [HttpDelete("{id}")]
        public void Delete(string id){
            
        }
    }
}