using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using RecensysBLL.BusinessLogicLayer;
using RecensysBLL.Models;
using RecensysBLL.Models.FullModels;
using RecensysRepository.Factory;

namespace ReviewIT_Backend.Controllers
{
    public class UserController : ApiController
    {

        private static UserBLL _userBLL = new UserBLL(new RepositoryFactoryMemory());
        

        // GET: api/Users
        public IEnumerable<UserModel> Get()
        {
            return null;
        }

        
        // GET: api/User/5
        public UserModel Get(int id)
        {

            // get dto from repo
            return _userBLL.Get(id);
            
            
        }

        // POST: api/User
        public void Post(UserModel user)
        {

            _userBLL.Add(user);
        }

        // PUT: api/User/5
        public void Put(int id, UserModel user)
        {
            _userBLL.Add(user);
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
            
        }

    }
}
