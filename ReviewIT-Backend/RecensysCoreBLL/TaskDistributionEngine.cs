using System;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.Repositories;

namespace RecensysCoreBLL
{
    public class TaskDistributionEngine : ITaskDistributionEngine
    {
        private readonly IDistributionRepository _distRepo;
        private readonly IRequestedDataRepository _rdRepo;
        private readonly ITaskRepository _tRepo;


        public TaskDistributionEngine(IDistributionRepository distRepo, IRequestedDataRepository rdRepo,
            ITaskRepository tRepo)
        {
            _distRepo = distRepo;
            _rdRepo = rdRepo;
            _tRepo = tRepo;
        }


        public int Generate(int stageId)
        {
            var createdTasks = 0;

            using (_rdRepo)
            using (_distRepo)
            using (_tRepo)
            {
                var work = _rdRepo.GetAll(stageId).ToList();
                var distDto = _distRepo.Read(stageId);
                var distribution = distDto.Distribution;

                var taskWeight = 100.0/work.Count;

                // TODO implment randomization in task distribution

                foreach (var a in work)
                {
                    foreach (var k in distribution.Keys)
                    {
                        if (distribution[k] > 0)
                        {
                            _tRepo.Create(stageId, new TaskDTO
                            {
                                ArticleId = a.ArticleId,
                                DataIds = a.DataIds,
                                OwnerId = k.Id
                            });
                            createdTasks++;
                            distribution[k] -= taskWeight;
                            break;
                        }
                    }
                }
            }

            return createdTasks;
        }

        public async Task<int> GenerateAsync(int stageId)
        {
            throw new NotImplementedException();
        }
    }
}