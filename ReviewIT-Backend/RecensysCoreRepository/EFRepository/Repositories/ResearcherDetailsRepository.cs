using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.Repositories;

namespace RecensysCoreRepository.EFRepository.Repositories
{
    public class ResearcherDetailsRepository: IResearcherDetailsRepository
    {

        private IRecensysContext _context;

        public ResearcherDetailsRepository(IRecensysContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<ResearcherDetailsDTO> Get()
        {
            return from r in _context.Users
                select new ResearcherDetailsDTO()
                {
                    Id = r.Id,
                    FirstName = r.FirstName
                };
        }
    }
}
