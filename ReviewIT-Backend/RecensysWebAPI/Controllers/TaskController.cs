using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RecensysBLL.BusinessEntities;
using RecensysBLL.BusinessLogicLayer;
using RecensysRepository.Factory;
using RecensysWebAPI.Models;
using Task = RecensysBLL.BusinessEntities.Task;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RecensysWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {

        private TaskBLL _taskBLL = new TaskBLL(new RepositoryFactoryMemory());

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return NoContent();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return NoContent();
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
