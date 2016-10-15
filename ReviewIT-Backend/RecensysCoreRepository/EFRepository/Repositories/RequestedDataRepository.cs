using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EFRepository.Entities;
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

        public IEnumerable<ArticleWithRequestedDataDTO> GetAll(int stageId)
        {
            var dtos = from i in _context.Inclusion
                where i.StageId == stageId
                select new ArticleWithRequestedDataDTO
                {
                    ArticleId = i.ArticleId,
                    DataIds = (from d in i.Article.Data
                              join sf in _context.StageFieldRelations on d.FieldId equals sf.FieldId
                              where sf.FieldType == FieldType.Requested
                              select d.Id).ToList()
                };

            return dtos;

        }




    }
}
