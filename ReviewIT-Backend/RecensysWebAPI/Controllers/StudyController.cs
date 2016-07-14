using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecensysBLL.BusinessEntities;
using RecensysBLL.BusinessLogicLayer;
using RecensysRepository.Factory;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RecensysWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudyController : Controller
    {

        private readonly StudyBLL studyBll;

        public StudyController(IRepositoryFactory factory)
        {
            studyBll = new StudyBLL(factory);
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<StudyOverview> Get()
        {
            return null;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
