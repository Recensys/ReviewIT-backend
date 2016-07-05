using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using RecensysBLL.BusinessLogicLayer;
using RecensysRepository.Factory;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RecensysWebAPI5.Controllers
{
    [Route("api/study/{studyId}/[controller]")]
    public class StageController : Controller
    {

        private readonly StageBLL _bll;
        public StageController(IRepositoryFactory factory)
        {
            _bll = new StageBLL(factory);
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new [] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int studyId, int id) => $"(stage with id {id} in study with id {studyId})";

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
