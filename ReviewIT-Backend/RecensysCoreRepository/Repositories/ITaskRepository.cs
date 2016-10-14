using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;

namespace RecensysCoreRepository.Repositories
{
    public interface ITaskRepository: IDisposable
    {
        int Create(int stageId, TaskDTO dto);
    }
}
