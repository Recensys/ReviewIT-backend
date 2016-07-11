using System;
using System.Collections.Generic;
using RecensysRepository.Entities;

namespace RecensysRepository.Interfaces
{
    public interface IFieldRepository : IDisposable
    {
        IEnumerable<FieldEntity> GetAll();

        void Create(FieldEntity item);

        FieldEntity Read(int id);

        void Update(FieldEntity item);

        void Delete(int id);
    }
}
