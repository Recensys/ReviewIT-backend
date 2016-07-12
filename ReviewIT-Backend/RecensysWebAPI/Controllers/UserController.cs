using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecensysBLL.BusinessEntities;
using RecensysBLL.BusinessLogicLayer;
using RecensysRepository.Factory;
using RecensysWebAPI.Models;
using SimpleCrypto;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RecensysWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly UserBLL userBll;
        public UserController(IRepositoryFactory factory)
        {
            userBll = new UserBLL(factory);
        }


        // GET: api/values
        [HttpGet("Count")]
        public int Count()
        {
            return userBll.Get().Count;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public int Get(int id)
        {
            return (int) HttpContext.Items["uid"];
        }

        // POST api/values
        [HttpPost("Create")]
        public void Post([FromBody]CredentialsModel model)
        {

            ICryptoService cryptoService = new PBKDF2();
            
            //save this salt to the database
            string salt = cryptoService.GenerateSalt();
            
            //save this hash to the database
            string hashedPassword = cryptoService.Compute(model.Password);

            userBll.CreateUser(new User()
            {
                Username = model.Username,
                Password = hashedPassword,
                PasswordSalt = salt
            });

            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
