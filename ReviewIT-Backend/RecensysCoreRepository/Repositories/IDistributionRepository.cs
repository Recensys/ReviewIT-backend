﻿using RecensysCoreRepository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecensysCoreRepository.Repositories
{
    public interface IDistributionRepository: IDisposable
    {
        void Create(DistributionDTO dto);
        DistributionDTO Read(int stageId);
        bool Update(DistributionDTO dto);
    }
}
