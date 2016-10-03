using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecensysCoreBLL.BusinessEntities;
using RecensysCoreBLL.BusinessLogicLayer;
using RecensysCoreRepository;
using RecensysCoreRepository.EF;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RecensysWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudyController : Controller
    {

        private readonly RepositoryFactory _factory;

        public StudyController(IRecensysContext context)
        {
            _factory = new RepositoryFactory(context);
        }


        /// <summary>
        /// Gets a list of basic details of studies
        /// </summary>
        /// <returns>Json array of study details</returns>
        [HttpGet("list")]
        public IActionResult Get()
        {
            try
            {
                using (var repo = _factory.GetStudyDetailsRepository)
                {
                    return Json(repo.GetAll().ToArray());
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("config/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                using (var repo = _factory.GetStudyConfigRepository)
                {
                    return Json(repo.Read(id));
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
