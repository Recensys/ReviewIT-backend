using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BibliographyParserCore.BibTex;
using BibliographyParserCore.ItemValidators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EFRepository;
using RecensysCoreRepository.Repositories;
using RecensysCoreBLL;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RecensysCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudyController : Controller
    {
        private readonly IStudyDetailsRepository _deRepo;
        private readonly IStudySourceRepository _soRepo;
        private readonly IStageDetailsRepository _sdRepo;
        private readonly ITaskDistributionEngine _tdEngine;
        private readonly IArticleRepository _aRepo;
        private readonly IStudyStartEngine _ssEngine;

        public StudyController(IStudyMemberRepository resRepo, IStudyDetailsRepository deRepo,
            IStudySourceRepository soRepo, IStageDetailsRepository sdRepo, ITaskDistributionEngine tdEngine,
            IArticleRepository aRepo, IStudyStartEngine ssEngine)
        {
            _deRepo = deRepo;
            _soRepo = soRepo;
            _sdRepo = sdRepo;
            _tdEngine = tdEngine;
            _aRepo = aRepo;
            _ssEngine = ssEngine;
        }

        [HttpGet("{id}/stages")]
        public IActionResult GetStages(int id)
        {
            try
            {
                using (_sdRepo)
                {
                    return Json(_sdRepo.GetAll(id));
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                using (_deRepo)
                {
                    return Json(_deRepo.Read(id));
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }



        [HttpPut]
        public IActionResult Put([FromBody] StudyDetailsDTO dto)
        {
            try
            {
                using (_deRepo)
                {
                    return Json(_deRepo.Update(dto));
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Gets a list of basic details of studies
        /// </summary>
        /// <returns>Json array of study details</returns>
        [HttpGet("list")]
        public IActionResult GetList()
        {
            try
            {
                using (_deRepo)
                {
                    return Json(_deRepo.GetAll().ToArray());
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] StudyDetailsDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                using (_deRepo)
                {
                    return Json(_deRepo.Create(dto));
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                using (_sdRepo)
                {
                    _deRepo.Delete(id);
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        

        [HttpPost]
        [Route("{id}/config/source")]
        public IActionResult Upload(int id, IFormFile file)
        {
            if (file == null) throw new Exception("File is null");
            if (file.Length == 0) throw new Exception("File is empty");

            int amountOfArticles;

            using (Stream stream = file.OpenReadStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var fileContent = reader.ReadToEnd();
                    var list = new BibTexParser(new ItemValidator()).Parse(fileContent);
                    amountOfArticles = list.Count;

                    using (_soRepo)
                    {
                        _soRepo.Post(id, list);
                    }
                }
            }
            return Ok(amountOfArticles);
        }

        [HttpGet("{id}/start")]
        public IActionResult Start(int id)
        {
            try
            {
                var tasksCreated = _ssEngine.StartStudy(id);
                return Json(tasksCreated);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        

    }
}
