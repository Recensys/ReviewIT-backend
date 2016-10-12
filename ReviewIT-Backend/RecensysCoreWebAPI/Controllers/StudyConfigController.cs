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

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RecensysCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudyController : Controller
    {

        private readonly IStudyResearcherRepository _studyResearcherRepository;
        private readonly IStudyDetailsRepository _deRepo;
        private readonly IStudyConfigRepository _coRepo;
        private readonly IStudySourceRepository _soRepo;

        public StudyController(IStudyResearcherRepository resRepo, IStudyDetailsRepository deRepo, IStudyConfigRepository coRepo, IStudySourceRepository soRepo)
        {
            _studyResearcherRepository = resRepo;
            _deRepo = deRepo;
            _coRepo = coRepo;
            _soRepo = soRepo;
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

        [HttpGet("{id}/config")]
        public IActionResult Get(int id)
        {
            try
            {
                using (_coRepo)
                {
                    return Json(_coRepo.Read(id));
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("config")]
        public IActionResult Post([FromBody] StudyConfigDTO dto)
        {
            try
            {
                using (_coRepo)
                {
                    return Ok(_coRepo.Create(dto));
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}/config")]
        public IActionResult Put([FromBody] StudyConfigDTO dto)
        {
            try
            {
                using (_coRepo)
                {
                    return Ok(_coRepo.Update(dto));
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                using (_coRepo)
                {
                    return Ok(_coRepo.Delete(id));
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

        [HttpPost("{id}/config/start")]
        public IActionResult Start(int id)
        {
            try
            {
                try
                {
                    using (_studyResearcherRepository)
                    {
                        return Ok();
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        

    }
}
