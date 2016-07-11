using System.Collections.Generic;
using System.Linq;
using RecensysBLL.Models;
using RecensysBLL.Models.FullModels;
using RecensysBLL.Models.OverviewModels;
using RecensysRepository.Factory;

namespace RecensysBLL.BusinessLogicLayer
{
    public class StageBLL
    {

        private readonly IRepositoryFactory _factory;
        public StageBLL(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        public List<StageOverviewModel> Get(int userId)
        {
            using (var repo = _factory.GetStageRepo())
            {
            }

            return null;
        }

        public StageModel Get(int id, int userId)
        {
            using (var repo = _factory.GetStageRepo())
            {

                var dto = repo.Read(id);

                return new StageModel()
                {
                    Id = id,
                    Name = dto.Name,
                    Description = dto.Description
                };
            }
        }

        


    }
}