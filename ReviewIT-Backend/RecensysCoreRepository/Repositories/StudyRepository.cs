using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EF;

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
            var StudyCon
        }
    }
}
