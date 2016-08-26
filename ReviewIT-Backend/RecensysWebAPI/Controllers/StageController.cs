using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RecensysBLL.BusinessEntities;
using RecensysBLL.BusinessLogicLayer;
using RecensysRepository.Entities;
using RecensysRepository.Factory;
using RecensysWebAPI.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RecensysWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class StageController : Controller
    {

        private StageBLL _stageBll;
        public StageController(IRepositoryFactory factory)
        {
            _stageBll = new StageBLL(factory);
        }

        


        // POST api/values
        [HttpPost("{id}/datafields")]
        public IActionResult Post(int id, [FromBody] StageDescriptionModel model)
        {

            try
            {
                _stageBll.UpdateFields(id, model.Visible, model.Requested);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }

        [HttpPost("{id}/details")]
        public IActionResult Post(int id, [FromBody] StageDetails model)
        {
            try
            {
                _stageBll.UpdateDetails(id, model);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Stage stage)
        {
            try
            {
                return Ok(_stageBll.SaveStage(stage));
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
                _stageBll.RemoveStage(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}