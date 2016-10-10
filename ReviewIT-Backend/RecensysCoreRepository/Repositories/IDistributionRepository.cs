using RecensysCoreRepository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecensysCoreRepository.Repositories
{
    public interface IDistributionRepository
    {
        void Create(DistributionDTO dto);
        DistributionDTO Read(int studyId);
        bool Update(DistributionDTO dto);
    }
}
