using System.Collections.Generic;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    public class DataRepositoryIm : IDataRepository
    {

        private List<DataEntity> _fieldData = new List<DataEntity>()
        {
            
        };

        public void Dispose()
        {
        }

        public IEnumerable<DataEntity> GetAll()
        {
            return _fieldData;
        }

        public void Create(DataEntity item)
        {
            _fieldData.Add(item);
        }

        public DataEntity Read(int id)
        {
            return _fieldData.Find(dto => dto.Id == id);
        }

        public void Update(DataEntity item)
        {
            _fieldData.RemoveAll(dto => dto.Id == item.Id);
            _fieldData.Add(item);
        }

        public void Delete(int id)
        {
            _fieldData.RemoveAll(dto => dto.Id == id);
        }
    }
}