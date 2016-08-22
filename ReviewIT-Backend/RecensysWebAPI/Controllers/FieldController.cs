using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecensysBLL.BusinessEntities;
using RecensysRepository.Factory;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RecensysWebAPI.Controllers
{
    [Route("api/study/{studyId}/field")]
    public class FieldController : Controller
    {

        private IRepositoryFactory _factory;
        public FieldController(IRepositoryFactory factory)
        {
            _factory = factory;
        }
        
        // GET api/values/5
        [HttpGet]
        public IActionResult Get(int studyId)
        {
            List<Field> fields = new List<Field>();
            using (var fieldRepo = _factory.GetFieldRepo())
            {
                foreach (var fieldEntity in fieldRepo.GetAll().Where(f => f.Study_Id == studyId))
                {
                    fields.Add(new Field()
                    {
                        Id = fieldEntity.Id,
                        Name = fieldEntity.Name,
                        DataType = (DataType)fieldEntity.DataType_Id
                    });
                }
            }
            return Json(fields);
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
