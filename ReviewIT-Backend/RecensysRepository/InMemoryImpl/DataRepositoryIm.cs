using System.Collections.Generic;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    public class DataRepositoryIm : IDataRepository
    {

        private List<DataEntity> _fieldData = new List<DataEntity>()
        {
            new DataEntity() {Id = 1, Field_Id = 1, Data = "jsondata"},
            new DataEntity() {Id = 2, Field_Id = 1, Data = "jsondata"},
            new DataEntity() {Id = 3, Field_Id = 1, Data = "jsondata"},
            new DataEntity() {Id = 4, Field_Id = 1, Data = "jsondata"},
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