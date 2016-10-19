using System;
using System.Linq;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EFRepository.Entities;

namespace RecensysCoreRepository.EFRepository.Repositories
{
    public class EFCriteriaRepository : ICriteriaRepository
    {
        private readonly RecensysContext _context;

        public EFCriteriaRepository(RecensysContext context)
        {
            if (context == null) throw new ArgumentNullException($"{nameof(context)} is null");
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public CriteriaDTO Read(int studyId)
        {
            var inclusions = (from c in _context.Criterias
                where (c.StudyId == studyId) && (c.Type == CriteriaType.Inclusion)
                select new FieldCriteriaDTO
                {
                    Id = c.Id,
                    Value = c.Value,
                    Operator = c.Operator,
                    Field = new FieldDTO
                    {
                        Id = c.Field.Id,
                        Name = c.Field.Name,
                        DataType = c.Field.DataType
                    }
                }).ToList();

            var exclusions = (from c in _context.Criterias
                where (c.StudyId == studyId) && (c.Type == CriteriaType.Exclusion)
                select new FieldCriteriaDTO
                {
                    Id = c.Id,
                    Value = c.Value,
                    Operator = c.Operator,
                    Field = new FieldDTO
                    {
                        Id = c.Field.Id,
                        Name = c.Field.Name,
                        DataType = c.Field.DataType
                    }
                }).ToList();

            return new CriteriaDTO
            {
                Inclusions = inclusions,
                Exclusions = exclusions
            };
        }

        public bool Update(int studyId, CriteriaDTO dto)
        {
            var stored = (from c in _context.Criterias
                where c.StudyId == studyId
                select c).ToList();

            // remove stored criteria that are not passed in dto
            if (dto.Inclusions != null)
                foreach (var to in stored) if (dto.Inclusions.All(c => c.Id != to.Id)) _context.Criterias.Remove(to);
            if (dto.Exclusions != null)
                foreach (var to in stored) if (dto.Exclusions.All(c => c.Id != to.Id)) _context.Criterias.Remove(to);

            if (dto.Inclusions != null)
                foreach (var inclusion in dto.Inclusions)
                {
                    if (inclusion.Id > 0)
                    {
                        var c = stored.Single(cr => cr.Id == inclusion.Id);
                        c.Operator = inclusion.Operator;
                        c.Value = inclusion.Value;
                    }
                    if (inclusion.Id == 0)
                    {
                        _context.Criterias.Add(Map(studyId, CriteriaType.Inclusion, inclusion));
                    }
                }

            if (dto.Exclusions != null)
                foreach (var exclusion in dto.Exclusions)
                {
                    if (exclusion.Id > 0)
                    {
                        var c = stored.Single(cr => cr.Id == exclusion.Id);
                        c.Operator = exclusion.Operator;
                        c.Value = exclusion.Value;
                    }
                    if (exclusion.Id == 0)
                    {
                        _context.Criterias.Add(Map(studyId, CriteriaType.Exclusion, exclusion));
                    }
                }
            return _context.SaveChanges() > 0;
        }

        private Criteria Map(int studyId, CriteriaType type, FieldCriteriaDTO dto)
        {
            return new Criteria
            {
                FieldId = dto.Field.Id,
                Operator = dto.Operator,
                StudyId = studyId,
                Value = dto.Value,
                Type = type
            };
        }
    }
}