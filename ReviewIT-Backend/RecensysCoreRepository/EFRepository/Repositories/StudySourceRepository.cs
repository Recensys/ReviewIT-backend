﻿using System;
using System.Collections.Generic;
using System.Linq;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EFRepository.Entities;
using RecensysCoreRepository.Repositories;

namespace RecensysCoreRepository.EFRepository.Repositories
{
    public class StudySourceRepository : IStudySourceRepository
    {
        private readonly RecensysContext _context;

        public StudySourceRepository(RecensysContext context)
        {
            if (context == null) throw new ArgumentNullException($"{nameof(context)} is null");
            _context = context;
        }

        public void Dispose()
        {
            
        }

        public void Post(int studyId, ICollection<StudySourceItemDTO> dtos)
        {
            var entityDictionary = new Dictionary<StudySourceItemDTO.FieldType, Field>();
            foreach (var fieldType in Enum.GetValues(typeof(StudySourceItemDTO.FieldType)))
            {
                // if datastore does not already contains a field
                var fieldEntity =
                    _context.Fields.FirstOrDefault(f => (f.StudyId == studyId) && (f.Name == fieldType.ToString()));
                if (fieldEntity == null)
                    fieldEntity = new Field
                    {
                        StudyId = studyId,
                        Name = fieldType.ToString()
                    };
                entityDictionary.Add((StudySourceItemDTO.FieldType) fieldType, fieldEntity);
            }

            // Add articles with data related to fields
            foreach (var dto in dtos)
            {
                var article = new Article
                {
                    StudyId = studyId,
                    Data = new List<Data>()
                };
                foreach (var fieldDto in dto.Fields)
                {
                    var d = new Data
                    {
                        Value = fieldDto.Value,
                        Field = entityDictionary[fieldDto.Key]
                    };

                    article.Data.Add(d);
                }
                _context.Articles.Add(article);
            }
            _context.SaveChanges();
        }
    }
}