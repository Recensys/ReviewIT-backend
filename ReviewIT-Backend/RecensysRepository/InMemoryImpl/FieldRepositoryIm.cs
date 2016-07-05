using System.Collections.Generic;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    public class FieldRepositoryIm : IFieldRepository
    {

        private List<FieldEntity> _fields = new List<FieldEntity>()
        {
            new FieldEntity() {Id = 1, Name = "Title", FieldType_Id = 1},
            new FieldEntity() {Id = 2, Name = "Is GSD?", FieldType_Id = 2}
        };

        public void Dispose()
        {
        }

        public IEnumerable<FieldEntity> GetAll()
        {
            return _fields;
        }

        public void Create(FieldEntity item)
        {
            _fields.Add(item);
        }

        public FieldEntity Read(int id)
        {
            return _fields.Find(dto => dto.Id == id);
        }

        public void Update(FieldEntity item)
        {
            _fields.RemoveAll(dto => dto.Id == item.Id);
            _fields.Add(item);
        }

        public void Delete(int id)
        {
            _fields.RemoveAll(dto => dto.Id == id);
        }
    }
}