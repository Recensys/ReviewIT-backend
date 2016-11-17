using System;
using System.Linq;
using System.Collections.Generic;
using RecensysCoreRepository.DTOs;
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

        public ArticleDTO Read(int id)
        {
            return (from a in _context.Articles
                where a.Id == id
                select new ArticleDTO
                {
                    Id = a.Id,
                    Data = (from d in a.Data
                            select new
                            {
                                field = new FieldDTO
                                {
                                    Id = d.Field.Id,
                                    Name = d.Field.Name,
                                    DataType = d.Field.DataType
                                },
                                data = new DataDTO
                                {
                                    Id = d.Id,
                                    Value = d.Value
                                }
                            })
                        .ToDictionary(r => r.field, t => t.data)
                }).Single();

        }

        public bool AddToStage(int stageId, int articleId)
        {
            _context.CriteriaResults.Add(new CriteriaResult
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

        public bool AddCriteriaResult(int criteriaId, int stageId, int articleId)
        {
            _context.CriteriaResults.Add(new CriteriaResult
            {
                ArticleId = articleId,
                CriteriaId = criteriaId,
                StageId = stageId
            });
            return _context.SaveChanges() > 0;
        }

        /// <summary>
        ///     An active article is defined by an article that's not excluded - thus either included or not affected by a criteria
        /// </summary>
        /// <param name="currentStage"></param>
        /// <returns></returns>
        public IEnumerable<int> GetAllActive(int currentStage)
        {
            int studyId = (from s in _context.Stages
                where s.Id == currentStage
                select s.StudyId).Single();

            //For some reason, this does not return the article if it's not affected by a criteria, so it has to be done with two calls to the db
            //return (from a in _context.Articles
            //        where a.StudyId == studyId && (!a.CriteriaResultId.HasValue || a.CriteriaResult.Criteria.Type != CriteriaType.Exclusion)
            //        select a.Id).ToArray();

            var unAffectedArticles = (from a in _context.Articles
                                      where a.StudyId == studyId && !a.CriteriaResultId.HasValue
                                      select a.Id).ToArray();

            var includedArticles = (from a in _context.Articles
                                    where a.StudyId == studyId && a.CriteriaResultId.HasValue && a.CriteriaResult.Criteria.Type != CriteriaType.Exclusion
                                    select a.Id).ToArray();

            var allArticleIds = unAffectedArticles.Concat(includedArticles);

            return allArticleIds;

        }

        public IEnumerable<ArticleWithRequestedFieldsDTO> GetAllWithRequestedFields(int stageId)
        {
            var articleIds = GetAllActive(stageId).ToArray();

            return from i in _context.Articles
                where articleIds.Any(aid => aid == i.Id)
                select new ArticleWithRequestedFieldsDTO
                {
                    ArticleId = i.Id,
                    FieldIds = (from sf in _context.StageFieldRelations
                                where sf.StageId == stageId && sf.FieldType == FieldType.Requested
                                select sf.FieldId).ToArray()
                };
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="current"></param>
        /// <param name="prevStage"></param>
        /// <returns>true if got prev stagId, false if there is no prev stage</returns>
        private bool TryGetPreviousStage(int current, out int prevStage)
        {
            var studyId = (from s in _context.Stages
                           where s.Id == current
                           select s.StudyId).Single();

            var stageIds = (from s in _context.Stages
                             where s.StudyId == studyId
                             orderby s.Id
                             select s.Id).ToArray();

            var index = Array.IndexOf(stageIds, current);
            if (index == 0)
            {
                prevStage = -1;
                return false;
            }
            else
            {
                prevStage = stageIds[index - 1];
                return true;
            }
        }
    }
}