using System.Collections.Generic;
using RecensysCoreRepository.Repositories;
using System.Linq;

namespace RecensysCoreBLL
{
    public class StudyStartEngine: IStudyStartEngine
    {

        private readonly ITaskDistributionEngine _tdEngine;
        private readonly ICriteriaEngine _cEngine;
        private readonly IStageDetailsRepository _sdRepo;
        private readonly IArticleRepository _aRepo;

        public StudyStartEngine(ITaskDistributionEngine tdEngine, IStageDetailsRepository sdRepo, IArticleRepository aRepo, ICriteriaEngine cEngine)
        {
            _tdEngine = tdEngine;
            _sdRepo = sdRepo;
            _aRepo = aRepo;
            _cEngine = cEngine;
        }

        public int StartStudy(int id)
        {

            // TODO do linked list or ref first stage from study
            // find stage with lowest id, and assume it's the first one
            int minStageId;
            using (_sdRepo)
            using(_aRepo)
            {
                minStageId = _sdRepo.GetAll(id).Min(sd => sd.Id);

                // add all articles to the first stage
                var articlesInStudy = _aRepo.GetAllIdsForStudy(id).ToList();
                foreach (var i in articlesInStudy)
                {
                    _aRepo.AddToStage(minStageId, i);
                }

                // create tasks for the first stage
                var nrOfTasksCreated = _tdEngine.Generate(minStageId);
                return nrOfTasksCreated;
            }
        }
    }
}