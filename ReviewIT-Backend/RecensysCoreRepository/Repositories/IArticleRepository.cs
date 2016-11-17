using System;
using System.Collections.Generic;
using RecensysCoreRepository.DTOs;

namespace RecensysCoreRepository.Repositories
{
    public interface IArticleRepository: IDisposable
    {
        ArticleDTO Read(int id);
        bool AddToStage(int stageId, int articleId);
        IEnumerable<int> GetAllIdsForStudy(int studyId);
        bool AddCriteriaResult(int criteriaId, int stageId, int articleId);
        IEnumerable<int> GetAllActive(int currentStage);
        IEnumerable<ArticleWithRequestedFieldsDTO> GetAllWithRequestedFields(int stageId);
    }
}