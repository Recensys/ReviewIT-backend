using System;
using System.Collections.Generic;
using RecensysRepository.Entities;

namespace RecensysRepository.Interfaces
{
    public interface IStageRepository : IDisposable
    {
        IEnumerable<StageEntity> GetAll();

        int Create(StageEntity item);

        StageEntity Read(int id);

        void Update(StageEntity item);

        void Delete(int id);
    }
}
