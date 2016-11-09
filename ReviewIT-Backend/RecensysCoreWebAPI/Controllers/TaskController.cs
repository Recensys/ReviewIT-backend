using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecensysCoreRepository.Repositories;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RecensysCoreWebAPI.Controllers
{
    [Route("api")]
    public class TaskController : Controller
    {

        private readonly IReviewTaskRepository _tRepo;

        public TaskController(IReviewTaskRepository tRepo)
        {
            _tRepo = tRepo;
        }

        // GET: api/values
        [HttpGet("tasks")]
        public IActionResult Get(int uid, int sid)
        {

            if (!ModelState.IsValid || uid == 0 || sid == 0) return BadRequest();

            try
            {
                using (_tRepo)
                {
                    return Json(_tRepo.GetListDto(sid, uid));
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        
    }
}
