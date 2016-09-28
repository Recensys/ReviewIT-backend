using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RecensysCoreBLL.BusinessLogicLayer;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EF;
using RecensysCoreRepository.Entities;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace RecensysCoreRepository.Repositories
{
    public class StudyRepository
    {
        private readonly RecensysContext _context;

        public StudyRepository(RecensysContext context)
        {
            if (context == null) throw new ArgumentNullException($"{nameof(context)} is null");
            _context = context;
        }


        public StudyConfigDTO GetConfigDto(int id)
        {
            return null;
        }

        public void UpdateConfig(StudyConfigDTO dto)
        {
            var entity = _context.Studies.Single(s => s.Id == dto.Id);

            
            
        }
    }

    
}