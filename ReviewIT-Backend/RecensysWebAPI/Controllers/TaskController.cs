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
            return Json(new Stage()
            {
                Id = 1,
                Name = "Name of Stage 1",
                Description = "Description of stage 1",
                Fields = new List<Field>()
                {
                    new Field()
                    {
                        Id = 1,
                        DataType = DataType.String,
                        Name = "Author",
                        Input = false
                    },
                    new Field()
                    {
                        Id = 2,
                        DataType = DataType.Number,
                        Name = "Year",
                        Input = false
                    }
                },
                Tasks = new List<RecensysBLL.BusinessEntities.Task>()
                {
                    new RecensysBLL.BusinessEntities.Task()
                    {
                        Id = 1,
                        TaskState = TaskState.InProgress,
                        Data = new List<Data>()
                        {
                            new Data() {Id = 1, Value = "Mathias Pedersen"},
                            new Data() {Id = 2, Value = "2004"}
                        }
                    },
                    new RecensysBLL.BusinessEntities.Task()
                    {
                        Id = 2,
                        TaskState = TaskState.InProgress,
                        Data = new List<Data>()
                        {
                            new Data() {Id = 1, Value = "Jacob Cholewa"},
                            new Data() {Id = 2, Value = "2007"}
                        }
                    }
                }
            });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {


            return Json(new Stage()
            {
                Id = 1,
                Name = "Name of Stage 1",
                Description = "Description of stage 1",
                Fields = new List<Field>()
                {
                    new Field()
                    {
                        Id = 1,
                        DataType = DataType.String,
                        Name = "Author",
                        Input = false
                    },
                    new Field()
                    {
                        Id = 2,
                        DataType = DataType.Number,
                        Name = "Year",
                        Input = false
                    }
                },
                Tasks = new List<RecensysBLL.BusinessEntities.Task>()
                {
                    new RecensysBLL.BusinessEntities.Task()
                    {
                        Id = 1,
                        TaskState = TaskState.InProgress,
                        Data = new List<Data>()
                        {
                            new Data() {Id = 1, Value = "Mathias Pedersen"},
                            new Data() {Id = 2, Value = "2004"}
                        }
                    }}
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
