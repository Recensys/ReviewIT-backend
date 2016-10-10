using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.Repositories;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RecensysCoreWebAPI.Controllers
{
    [Route("api/study/{studyId}/researchers")]
    public class StudyResearchersController : Controller
    {


        private readonly IStudyResearcherRepository _studyResearcherRepository;

        public StudyResearchersController(IStudyResearcherRepository studyResearcherRepository)
        {
            _studyResearcherRepository = studyResearcherRepository;
        }

        [HttpGet]
        public IActionResult Get(int studyId)
        {
            try
            {
                using (_studyResearcherRepository)
                {
                    return Json(_studyResearcherRepository.Get(studyId));
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }




        [HttpPost]
        public IActionResult Post(int studyId, [FromBody]StudyResearcherDTO dto)
        {
            try
            {
                using (_studyResearcherRepository)
                {
                    _studyResearcherRepository.Create(studyId, dto);
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(int studyId, [FromBody] StudyResearcherDTO[] dtos)
        {
            try
            {
                using (_studyResearcherRepository)
                {
                    _studyResearcherRepository.Update(studyId, dtos);
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
