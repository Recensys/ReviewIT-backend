using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;

namespace RecensysCoreRepository.Repositories
{
    public interface IStageFieldsRepository : IDisposable
    {
        StageFieldsDTO Get(int stageId);
        Task<StageFieldsDTO> GetAsync(int stageId);
        bool Update(int stageId, StageFieldsDTO dto);
        Task<bool> UpdateAsync(int stageId, StageFieldsDTO dto);
    }
}
