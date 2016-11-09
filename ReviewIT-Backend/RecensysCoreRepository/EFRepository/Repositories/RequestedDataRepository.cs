using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EFRepository.Entities;
using RecensysCoreRepository.Repositories;
using FieldType = RecensysCoreRepository.DTOs.FieldType;

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

        public IEnumerable<ArticleWithRequestedFieldsDTO> GetAll(int stageId)
        {

            var dtos = from i in _context.StageArticleRelations
                where i.StageId == stageId
                select new ArticleWithRequestedFieldsDTO
                {
                    ArticleId = i.ArticleId,
                    FieldIds = (from sf in _context.StageFieldRelations
                               where sf.StageId == stageId && sf.FieldType == FieldType.Requested
                               select sf.FieldId).ToArray()
                };

            return dtos;
        }

        public ArticleWithRequestedFieldsDTO Read(int articleId)
        {
            throw new NotImplementedException();
        }
    }
}
