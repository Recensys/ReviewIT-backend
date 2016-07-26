using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecensysBLL.BusinessEntities;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RecensysWebAPI.Controllers
{
    [Route("api/study/{studyId}/field")]
    public class FieldController : Controller
    {


        
        // GET api/values/5
        [HttpGet]
        public ActionResult Get(int studyId)
        {
            return Json(new List<Field>()
            {
                new Field() {Id = 1, DataType = DataType.String, Name = "Title"},
                new Field() {Id = 2, Name = "isGSD?", DataType = DataType.Boolean}
            });
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
