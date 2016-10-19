﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;

namespace RecensysCoreRepository.Repositories
{
    public interface IStageDetailsRepository: IDisposable
    {
        StageDetailsDTO Read(int id);
        int Create(int studyId, StageDetailsDTO dto);
        bool Update(StageDetailsDTO dto);
        ICollection<StageDetailsDTO> GetAll(int studyId);
    }
}
