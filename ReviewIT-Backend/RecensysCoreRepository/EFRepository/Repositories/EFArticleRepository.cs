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
    }
}