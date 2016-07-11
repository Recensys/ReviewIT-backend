using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RecensysBLL.BusinessLogicLayer;
using RecensysBLL.Models;
using RecensysBLL.Models.FullModels;
using RecensysBLL.Models.OverviewModels;
using RecensysRepository.Factory;

namespace ReviewIT_Backend.Controllers
{
    public class StageController : ApiController
    {

        private static StageBLL _bll = new StageBLL(new RepositoryFactoryMemory());

        // GET: api/Stage
        public IEnumerable<StageOverviewModel> Get()
        {
            return null;
        }

        // GET: api/Stage/5
        public StageModel Get(int id)
        {
            return _bll.Get(id, 0);
        }

        // POST: api/Stage
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Stage/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Stage/5
        public void Delete(int id)
        {
        }
    }
}
