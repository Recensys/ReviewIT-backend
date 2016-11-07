using System;
using System.Linq;
using System.Collections.Generic;
using RecensysCoreRepository.EFRepository.Entities;
using RecensysCoreRepository.Repositories;

namespace RecensysCoreRepository.EFRepository.Repositories
{
    public class EFArticleRepository: IArticleRepository
    {
        private readonly RecensysContext _context;

        public EFArticleRepository(RecensysContext context)
        {
            if (context == null) throw new ArgumentNullException($"{nameof(context)} is null");
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool AddToStage(int stageId, int articleId)
        {
            _context.StageArticleRelations.Add(new StageArticleRelation
            {
                StageId = stageId,
                ArticleId = articleId
            });

            return _context.SaveChanges() > 0;
        }

        public IEnumerable<int> GetAllIdsForStudy(int studyId)
        {
            return from a in _context.Articles
                where a.StudyId == studyId
                select a.Id;
        }

        public IEnumerable<int> GetAllIncludedFromPreviousStage(int currentStage)
        {
            var prevStageId = PreviousStage(currentStage);

            return from sa in _context.StageArticleRelations
                where sa.StageId == prevStageId && (sa.CriteriaId == null || sa.Criteria.Type == CriteriaType.Inclusion)
                select sa.ArticleId;
        }

        public int PreviousStage(int current)
        {
            var studyId = (from s in _context.Stages
                           where s.Id == current
                           select s.StudyId).Single();

            var prevStage = (from s in _context.Stages
                             where s.StudyId == studyId
                             orderby s.Id
                             select s.Id).ToList();

            return prevStage[prevStage.IndexOf(current) - 1];
        }
    }
}