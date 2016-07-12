using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RecensysRepository.Entities;

namespace RecensysRepository.Interfaces
{
    public interface IDataTypeRepository : IDisposable
    {
        IEnumerable<DataTypeEntity> GetAll();

        void Create(DataTypeEntity item);

        DataTypeEntity Read(int id);

        void Update(DataTypeEntity item);

        void Delete(int id);
    }
}
