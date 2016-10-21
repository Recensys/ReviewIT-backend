using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecensysCoreRepository.Repositories;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RecensysCoreWebAPI.Controllers
{
    [Route("api/")]
    public class FieldController : Controller
    {

        private IFieldRepository _repo;

        public FieldController(IFieldRepository repo)
        {
            _repo = repo;
        }


        // GET: api/values
        [HttpGet("study/{studyId}/fields/search/{term}")]
        public IActionResult Get(int studyId, string term)
        {
            try
            {
                using (_repo)
                {
                    var results = from r in _repo.GetAll(studyId)
                                  where r.Name.ToLower().Contains(term.ToLower())
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
