using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EFRepository.Repositories;
using RecensysCoreRepository.Repositories;

namespace RecensysCoreBLL
{
    public class TaskEngine: ITaskEngine
    {

        private readonly IDistributionRepository _distRepo;
        private readonly IStageFieldsRepository _sfRepo;
        private readonly ITaskRepository _tRepo;
        private readonly IArticleRepository _aRepo;
        private readonly IRequestedDataRepository _rdRepo;


        public TaskEngine(IDistributionRepository distRepo, IStageFieldsRepository sfRepo, ITaskRepository tRepo, IArticleRepository aRepo, IRequestedDataRepository rdRepo)
        {
            _distRepo = distRepo;
            _sfRepo = sfRepo;
            _tRepo = tRepo;
            _aRepo = aRepo;
            _rdRepo = rdRepo;
        }


        public int Generate(int stageId)
        {
            using (_distRepo)
            using (_sfRepo)
            using (_tRepo)
            using (_aRepo)
            using(_rdRepo)
            {
                var requestedData = _rdRepo.GetAll(stageId);
            }

            return 0;
        }

        public async Task<int> GenerateAsync(int stageId)
        {
            throw new NotImplementedException();
        }
    }
}
