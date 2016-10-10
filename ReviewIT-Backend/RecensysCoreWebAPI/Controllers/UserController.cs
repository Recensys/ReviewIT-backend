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

    [Route("api")]
    public class UserController : Controller
    {

        private IResearcherDetailsRepository _researcherDetailsRepository;

        public UserController(IResearcherDetailsRepository researcherDetailsRepository)
        {
            _researcherDetailsRepository = researcherDetailsRepository;
        }

        [HttpGet("users")]
        public IActionResult Get()
        {
            try
            {
                using (_researcherDetailsRepository)
                {
                    return Json(_researcherDetailsRepository.Get());
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("users/{search}")]
        public IActionResult Get(string search)
        {
            try
            {
                using (_researcherDetailsRepository)
                {
                    var results = from r in _researcherDetailsRepository.Get()
                        where r.FirstName.ToLower().Contains(search.ToLower())
                        select r;
                    return Json(results.ToList());
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
