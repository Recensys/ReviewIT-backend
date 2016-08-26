using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    class Strategy_Field_RelationRepositoryIm : IStrategy_Field_RelationRepository
    {
        private List<Strategy_Field_RelationEntity> _entities = new List<Strategy_Field_RelationEntity>();
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Strategy_Field_RelationEntity> GetAll()
        {
            return _entities;;
        }

        public int Create(Strategy_Field_RelationEntity item)
        {
            _entities.Add(item);
            return _entities.IndexOf(item);
        }

        public Strategy_Field_RelationEntity Read(int id)
        {
            return _entities.Find(e => e.Field_Id == id);
        }

        public void Update(Strategy_Field_RelationEntity item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
