using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.Repositories;

namespace RecensysCoreRepository.EFRepository.Repositories
{
    public class RequestedDataRepository: IRequestedDataRepository
    {

        private readonly RecensysContext _context;

        public RequestedDataRepository(RecensysContext context)
        {
            if (context == null) throw new ArgumentNullException($"{nameof(context)} is null");
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<RequestedDataDTO> GetAll(int stageId)
        {
            return from d in _context.Data
                where d.Article.StudyId == 0
                select new RequestedDataDTO() {Id = d.Id, ArticleId = d.ArticleId};
        }




    }
}
