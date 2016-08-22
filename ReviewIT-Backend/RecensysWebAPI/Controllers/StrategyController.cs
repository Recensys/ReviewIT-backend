using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecensysRepository.Entities;
using RecensysRepository.Factory;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RecensysWebAPI.Controllers
{
    [Route("api/study{studyId}/stage/{stageId}/[controller]")]
    public class StrategyController : Controller
    {

        private IRepositoryFactory _factory;
        public StrategyController(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost("{strategy}")]
        public void Post(int stageId, int strategy)
        {
            using (var strategyRepo = _factory.GetStrategyRepo())
            {
                strategyRepo.Create(new StrategyEntity()
                {
                    Stage_Id = stageId,
                    Value = strategy.ToString()
                });
            }
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
