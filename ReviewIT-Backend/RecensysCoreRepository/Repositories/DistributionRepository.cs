using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EF;

namespace RecensysCoreRepository.Repositories
{
    public class DistributionRepository : IDistributionRepository
    {
        
        private readonly IRecensysContext _context;

        public DistributionRepository(IRecensysContext context)
        {
            if (context == null) throw new ArgumentNullException($"{nameof(context)} is null");
            _context = context;
        }

        public void Create(DistributionDTO dto)
        {
            _context.Strategies.Add(new Entities.Strategy() {});
        }

        public DistributionDTO Read(int studyId)
        {
            throw new NotImplementedException();
        }

        public bool Update(DistributionDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
