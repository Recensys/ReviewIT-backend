using System;
using System.Linq;
using Newtonsoft.Json;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EFRepository.Entities;
using RecensysCoreRepository.Repositories;

namespace RecensysCoreRepository.EFRepository.Repositories
{
    public class DistributionRepository : IDistributionRepository
    {
        
        private readonly RecensysContext _context;

        public DistributionRepository(RecensysContext context)
        {
            if (context == null) throw new ArgumentNullException($"{nameof(context)} is null");
            _context = context;
        }

        public void Create(DistributionDTO dto)
        {
            var strategy = new Strategy()
            {
                StageId = dto.StageId,
                StrategyType = StrategyType.Distribution,
                Value = JsonConvert.SerializeObject(dto)
            };

            _context.Strategies.Add(strategy);
        }

        public DistributionDTO Read(int stageId)
        {
            var q = from s in _context.Strategies
                where s.StageId == stageId && s.StrategyType == StrategyType.Distribution
                select JsonConvert.DeserializeObject<DistributionDTO>(s.Value);
            return q.First();
        }

        public bool Update(DistributionDTO dto)
        {
            var strategy = (from s in _context.Strategies
                where s.StageId == dto.StageId && s.StrategyType == StrategyType.Distribution
                select s).First();
            strategy.Value = JsonConvert.SerializeObject(dto.Distribution);
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
