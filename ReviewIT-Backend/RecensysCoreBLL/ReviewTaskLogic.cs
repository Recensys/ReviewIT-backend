using System;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.Repositories;

namespace RecensysCoreBLL
{
    public class ReviewTaskLogic: IReviewTaskLogic
    {

        private readonly IReviewTaskRepository _tRepo;
        private readonly IPostStageEngine _postEngine;
        public ReviewTaskLogic(IReviewTaskRepository tRepo, IPostStageEngine postEngine)
        {
            _tRepo = tRepo;
            _postEngine = postEngine;
        }

        public bool Update(ReviewTaskDTO dto)
        {
            using (_tRepo)
            {
                var r = _tRepo.Update(dto);

                var stageId = _tRepo.GetStageId(dto);

                // if there are no incomplete, move on to next stage
                if (_tRepo.CountIncomplete(stageId) <= 0) _postEngine.Evaluate(stageId);

                return r;
            }
        }
    }
}