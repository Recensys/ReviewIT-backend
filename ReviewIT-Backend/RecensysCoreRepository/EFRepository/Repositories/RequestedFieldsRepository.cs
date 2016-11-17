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
    public class RequestedFieldsRepository: IRequestedFieldsRepository
    {

        private readonly RecensysContext _context;
        private readonly IArticleRepository _aRepo;

        public RequestedFieldsRepository(RecensysContext context, IArticleRepository aRepo)
        {
            if (context == null) throw new ArgumentNullException($"{nameof(context)} is null");
            _context = context;
            _aRepo = aRepo;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<ArticleWithRequestedFieldsDTO> GetAll(int stageId)
        {

            // get all articles

            // get all requested fields in the stage per article

            // TODO move to article repo

            using (_aRepo)
            {
                _aRepo.GetAllActive()
            }

            var dtos = from i in _context.Articles
                where i.StudyId
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
