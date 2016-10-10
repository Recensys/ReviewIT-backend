using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design.Core.Utilities.Internal;
using Newtonsoft.Json;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EF;
using RecensysCoreRepository.Entities;

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
            var strategy = new Strategy()
            {
                StageId = dto.StageId,
                Type = StrategyType.Distribution,
                Value = JsonConvert.SerializeObject(dto)
            };

            _context.Strategies.Add(strategy);
        }

        public DistributionDTO Read(int studyId)
        {
            var q = from s in _context.Strategies
            return 
        }

        public bool Update(DistributionDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
