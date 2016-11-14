using System;
using RecensysCoreRepository.DTOs;

namespace RecensysCoreRepository.Repositories
{
    public interface IReviewTaskRepository: IDisposable
    {
        ReviewTaskListDTO GetListDto(int stageId, int userId);
        bool Update(ReviewTaskDTO dto);
        int CountIncomplete(int stageId);
        int GetStageId(ReviewTaskDTO dto);
    }
}