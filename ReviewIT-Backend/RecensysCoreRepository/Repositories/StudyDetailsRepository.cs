using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EF;

namespace RecensysCoreRepository.Repositories
{
    public class StudyDetailsRepository : IDisposable
    {
        private readonly RecensysContext _context;

        public StudyDetailsRepository(RecensysContext context)
        {
            if (context == null) throw new ArgumentNullException($"{nameof(context)} is null");
            _context = context;
        }

        public IEnumerable<StudyDetailsDTO> GetAll()
        {
            return from s in _context.Studies
                    select new StudyDetailsDTO {Id = s.Id, Name = s.Title, Description = s.Description};
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
