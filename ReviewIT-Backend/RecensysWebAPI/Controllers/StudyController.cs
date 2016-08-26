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

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(studyBll.Get());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet("new")]
        public IActionResult NewStudy()
        {
            try
            {
                return Json(studyBll.NewStudy());

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == -1)
            {
                return Json(new Study());
            }

            try
            {
                return Json(studyBll.Get(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST api/values
        [HttpPost("{id}/start")]
        public IActionResult Post(int id)
        {
            try
            {
                int nrOfCreatedTasks = studyBll.StartStudy(id);
                return Json(new { NrOfCreatedTasks = nrOfCreatedTasks});
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Study study)
        {
            try
            {
                studyBll.UpdateStudy(study);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                studyBll.Remove(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
                
            }
        }
    }
}
