using System.Collections.Generic;
using System.Linq;
using RecensysBLL.BusinessEntities;
using RecensysRepository.Entities;
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


        public int AddStage(Stage stage, int studyId)
        {
            var id = -1;
            using (var stageRepo = _factory.GetStageRepo())
            {
                id = stageRepo.Create(new StageEntity()
                {
                    Study_Id = studyId,
                    Name = stage.Name,
                    Description = stage.Description
                });
            }
            return id;
        }

        public void RemoveStage(int id)
        {
            using (var stageRepo = _factory.GetStageRepo())
            {
                stageRepo.Delete(id);
            }
        }


    }
}