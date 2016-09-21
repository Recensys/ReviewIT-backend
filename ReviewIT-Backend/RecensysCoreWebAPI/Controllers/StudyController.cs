using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecensysCoreBLL.BusinessEntities;
using RecensysCoreBLL.BusinessLogicLayer;
using RecensysCoreRepository;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RecensysWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudyController : Controller
    {

        private readonly StudyBLL studyBll;
        private readonly IRepositoryFactory _factory;

        public StudyController(IRepositoryFactory factory)
        {
            _factory = factory;
            studyBll = new StudyBLL(factory); 
        }
       
        

        // GET api/values/5
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (var repo = _factory.GetRepo<RecensysCoreRepository.Entities.Study>())
                {
                    return Json(repo.GetAll().ToList());
                }
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
            try
            {
                using (var repo = _factory.GetRepo<RecensysCoreRepository.Entities.Study>())
                {
                    return Json(repo.Read(id));
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        // PUT api/values/5
        [HttpPost("{id}")]
        public IActionResult Put(int id, [FromBody]Study study)
        {
           
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
