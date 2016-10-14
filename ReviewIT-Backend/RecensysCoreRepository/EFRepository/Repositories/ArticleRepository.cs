using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;

namespace RecensysCoreRepository.EFRepository.Repositories
{
    public class ArticleRepository: IArticleRepository
    {
        private readonly RecensysContext _context;

        public ArticleRepository(RecensysContext context)
        {
            if (context == null) throw new ArgumentNullException($"{nameof(context)} is null");
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<ArticleDTO> GetAllForStudy(int studyId)
        {
            return from a in _context.Articles
                where a.StudyId == studyId
                select new ArticleDTO() {Id = a.Id};
        }

        public IEnumerable<ArticleDTO> GetAllForStage(int studyId)
        {
            throw new NotImplementedException();
        }
    }
}
