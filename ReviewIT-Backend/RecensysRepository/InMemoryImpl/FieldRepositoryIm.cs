using System;
using System.Collections.Generic;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    public class FieldRepositoryIm : IFieldRepository
    {

        private List<FieldEntity> _fields = new List<FieldEntity>()
        {
            new FieldEntity() {Id = 0, Name = "Title", Study_Id = 0, DataType_Id = 0},
            new FieldEntity() {Id = 1, Name = "Author", Study_Id = 0, DataType_Id = 0},
            new FieldEntity() {Id = 2, Name = "Abstract", Study_Id = 0, DataType_Id = 0},
            new FieldEntity() {Id = 3, Name = "isGSD?", Study_Id = 0, DataType_Id = 1},
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