using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RecensysBLL.BusinessLogicLayer;
using RecensysRepository.Factory;
using RecensysWebAPI.Models;
using RecensysWebAPI.Services;
using SimpleCrypto;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RecensysWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        private readonly UserBLL userBll;

        public LoginController(IRepositoryFactory factory)
        {
            userBll = new UserBLL(factory);
        }

        

        [HttpPost]
        public IActionResult Login([FromBody]CredentialsModel model)
        {
            
            if (ModelState.IsValid & model != null)
            {
                var user = userBll.Get(model.Username);
                
                ICryptoService cryptoService = new PBKDF2();

                cryptoService.Salt = user.PasswordSalt;

                string inputHash = cryptoService.Compute(model.Password);
                bool isPasswordValid = cryptoService.Compare(user.Password, inputHash);



                if (isPasswordValid)
                {
                    var tokenService = new JWTTokenService();
                    var token = tokenService.GetToken(user.Id);

                    user.Password = null;
                    user.PasswordSalt = null;
                    return Json(new { token, user});
                }
            }

            return Forbid();


        }

        
    }
}
