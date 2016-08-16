using System.Collections.Generic;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    public class DataRepositoryIm : IDataRepository
    {

        private List<DataEntity> _fieldData = new List<DataEntity>()
        {
            new DataEntity() {Id = 0, Article_Id = 0, Field_Id = 0, Task_Id = 0, Value = "Global software teams: collaborating across borders and time zones"},
            new DataEntity() {Id = 1, Article_Id = 0, Field_Id = 1, Task_Id = 0, Value = ""},
            new DataEntity() {Id = 3, Article_Id = 1, Field_Id = 0, Task_Id = 1, Value = "Code of medical ethics"},
            new DataEntity() {Id = 4, Article_Id = 1, Field_Id = 1, Task_Id = 1, Value = ""},
            new DataEntity() {Id = 5, Article_Id = 2, Field_Id = 0, Task_Id = 2, Value = "Tactical approaches for alleviating distance in global software development"},
            new DataEntity() {Id = 6, Article_Id = 2, Field_Id = 1, Task_Id = 2, Value = ""},
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