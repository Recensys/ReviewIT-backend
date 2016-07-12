using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    class DataTypeRepositoryIm : IDataTypeRepository
    {

        private List<DataTypeEntity> _data = new List<DataTypeEntity>();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataTypeEntity> GetAll()
        {
            return _data;
        }

        public void Create(DataTypeEntity item)
        {
            _data.Add(item);
        }

        public DataTypeEntity Read(int id)
        {
            return _data.Find(entity => entity.Id == id);
        }

        public void Update(DataTypeEntity item)
        {
            _data.RemoveAll(entity => entity.Id == item.Id);
            _data.Add(item);
        }

        public void Delete(int id)
        {
            _data.RemoveAll(entity => entity.Id == id);
        }
    }
}
