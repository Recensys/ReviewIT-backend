using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RecensysBLL.BusinessEntities;
using RecensysWebAPI.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RecensysWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class StageController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Json(new[]
            {
                new Stage
                {
                    Id = 1,
                    Name = "Name of Stage 1",
                    Description = "Description of stage 1",
                    Fields = new List<Field>
                    {
                        new Field
                        {
                            Id = 1,
                            DataType = DataType.String,
                            Name = "Author",
                            Input = false
                        },
                        new Field
                        {
                            Id = 2,
                            DataType = DataType.Number,
                            Name = "Year",
                            Input = false
                        }
                    },
                    Tasks = new List<Task>
                    {
                        new Task
                        {
                            Id = 1,
                            TaskState = TaskState.InProgress,
                            Data = new List<Data>
                            {
                                new Data {Id = 1, Value = "Mathias Pedersen"},
                                new Data {Id = 2, Value = "2004"}
                            }
                        },
                        new Task
                        {
                            Id = 2,
                            TaskState = TaskState.InProgress,
                            Data = new List<Data>
                            {
                                new Data {Id = 1, Value = "Jacob Cholewa"},
                                new Data {Id = 2, Value = "2007"}
                            }
                        }
                    }
                },
                new Stage
                {
                    Id = 2,
                    Name = "Name of Stage 2",
                    Description = "Description of stage 2",
                    Fields = new List<Field>
                    {
                        new Field
                        {
                            Id = 1,
                            DataType = DataType.String,
                            Name = "Author",
                            Input = false
                        },
                        new Field
                        {
                            Id = 2,
                            DataType = DataType.Number,
                            Name = "Year",
                            Input = false
                        }
                    },
                    Tasks = new List<Task>
                    {
                        new Task
                        {
                            Id = 1,
                            TaskState = TaskState.InProgress,
                            Data = new List<Data>
                            {
                                new Data {Id = 1, Value = "Mathias Pedersen"},
                                new Data {Id = 2, Value = "2004"}
                            }
                        },
                        new Task
                        {
                            Id = 2,
                            TaskState = TaskState.InProgress,
                            Data = new List<Data>
                            {
                                new Data {Id = 1, Value = "Jacob Cholewa"},
                                new Data {Id = 2, Value = "2007"}
                            }
                        }
                    }
                }
            });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Json(new Stage
            {
                Id = 1,
                Name = "Name of Stage 1",
                Description = "Description of stage 1",
                Fields = new List<Field>
                {
                    new Field
                    {
                        Id = 1,
                        DataType = DataType.String,
                        Name = "Author",
                        Input = false
                    },
                    new Field
                    {
                        Id = 2,
                        DataType = DataType.Number,
                        Name = "Year",
                        Input = false
                    }
                },
                Tasks = new List<Task>
                {
                    new Task
                    {
                        Id = 1,
                        TaskState = TaskState.InProgress,
                        Data = new List<Data>
                        {
                            new Data {Id = 1, Value = "Mathias Pedersen"},
                            new Data {Id = 2, Value = "2004"}
                        }
                    },
                    new Task
                    {
                        Id = 2,
                        TaskState = TaskState.InProgress,
                        Data = new List<Data>
                        {
                            new Data {Id = 1, Value = "Jacob Cholewa"},
                            new Data {Id = 2, Value = "2007"}
                        }
                    }
                }
            });
        }

        // POST api/values
        [HttpPost("datafields")]
        public IActionResult Post([FromBody] StageDescriptionModel model)
        {

            if (model != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}