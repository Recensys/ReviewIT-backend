using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BibliographyParserCore.BibTex;
using BibliographyParserCore.ItemValidators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EF;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RecensysCoreWebAPI.Controllers
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

        [HttpGet("{id}/config")]
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

        [HttpPost("config")]
        public IActionResult Post([FromBody] StudyConfigDTO dto)
        {
            try
            {
                using (var repo = _factory.GetStudyConfigRepository)
                {
                    return Ok(repo.Create(dto));
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
                using (var repo = _factory.GetStudyConfigRepository)
                {
                    return Ok(repo.Update(dto));
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
                using (var repo = _factory.GetStudyConfigRepository)
                {
                    return Ok(repo.Delete(id));
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

                    using (var repo = _factory.GetStudySourceRepository)
                    {
                        repo.Post(id, list);
                    }
                }
            }
            return Ok(amountOfArticles);
        }
    }
}
