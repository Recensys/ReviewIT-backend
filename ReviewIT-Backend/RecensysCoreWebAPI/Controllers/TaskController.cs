using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecensysCoreBLL;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.Repositories;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RecensysCoreWebAPI.Controllers
{
    [Route("api")]
    public class TaskController : Controller
    {

        private readonly IReviewTaskRepository _tRepo;
        private readonly IReviewTaskLogic _tLogic;

        public TaskController(IReviewTaskRepository tRepo, IReviewTaskLogic tLogic)
        {
            _tRepo = tRepo;
            _tLogic = tLogic;
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

        [HttpPut("tasks")]
        public IActionResult Put([FromBody] ReviewTaskDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return _tLogic.Update(dto) ? NoContent() : StatusCode(500);
        }
        
        
    }
}
