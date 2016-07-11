using System;
using System.Collections.Generic;
using RecensysRepository.Entities;

namespace RecensysRepository.Interfaces
{
    public interface IDataRepository : IDisposable
    {
        IEnumerable<DataEntity> GetAll();

        void Create(DataEntity item);

        DataEntity Read(int id);

        void Update(DataEntity item);

        void Delete(int id);
    }
}
