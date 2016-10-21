using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.Repositories;

namespace RecensysCoreRepository.EFRepository.Repositories
{
    public class FieldRepository: IFieldRepository
    {
        private readonly RecensysContext _context;

        public FieldRepository(RecensysContext context)
        {
            if (context == null) throw new ArgumentNullException($"{nameof(context)} is null");
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<FieldDTO> GetAll(int studyId)
        {
            return from f in _context.Fields
                where f.StudyId == studyId
                select new FieldDTO
                {
                    Id = f.Id,
                    Name = f.Name,
                    DataType = f.DataType
                };
        }
    }
}
