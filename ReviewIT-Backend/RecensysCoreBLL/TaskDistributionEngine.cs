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
        private readonly ITaskConfigRepository _tRepo;


        public TaskDistributionEngine(IDistributionRepository distRepo, IRequestedDataRepository rdRepo,
            ITaskConfigRepository tRepo)
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
                var articles = _rdRepo.GetAll(stageId).ToList();
                var distDto = _distRepo.Read(stageId);
                var dist = distDto.Dist;

                var taskWeight = 100.0 / articles.Count;
                var articleNr = 1;

                // TODO implment randomization in task distribution

                foreach (var a in articles)
                {
                    var p = (articleNr * taskWeight) - taskWeight;
                    foreach (var d in dist)
                    {
                        if (InRange(p, d.Range[0], d.Range[1]))
                        {
                            _tRepo.Create(stageId, new ReviewTaskConfigDTO
                            {
                                ArticleId = a.ArticleId,
                                OwnerId = d.Id,
                                RequestedDataIds = a.DataIds 
                            });
                            createdTasks++;
                        }
                    }
                    articleNr++;
                }
            }
            return createdTasks;
        }

        private bool InRange(double numberToCheck, double bottom, double top)
        {
            return numberToCheck >= bottom && numberToCheck < top;
        }

        public async Task<int> GenerateAsync(int stageId)
        {
            throw new NotImplementedException();
        }
    }
}