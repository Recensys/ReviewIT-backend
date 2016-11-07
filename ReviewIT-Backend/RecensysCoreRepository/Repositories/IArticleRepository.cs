using System;
using System.Collections.Generic;

namespace RecensysCoreRepository.Repositories
{
    public interface IArticleRepository: IDisposable
    {
        bool AddToStage(int stageId, int articleId);
        IEnumerable<int> GetAllIdsForStudy(int studyId);

        IEnumerable<int> GetAllIncludedFromPreviousStage(int currentStage);
    }
}