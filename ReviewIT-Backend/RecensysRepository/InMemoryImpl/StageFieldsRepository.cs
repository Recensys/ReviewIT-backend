using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    class StageFieldsRepository : IStageFieldsRepository
    {

        private List<StageFieldEntity> _entities = new List<StageFieldEntity>();

        public void Dispose()
        {
            
        }

        public IEnumerable<StageFieldEntity> GetAll()
        {
            return _entities;
        }

        public int Create(StageFieldEntity item)
        {
            _entities.Add(item);
            return _entities.IndexOf(item);
        }

        public StageFieldEntity Read(int stageId, int fieldId)
        {
            return _entities.Find(e => e.Stage_Id == stageId && e.Field_Id == fieldId);
        }

        public void Update(StageFieldEntity item)
        {
            _entities.RemoveAll(e => e.Stage_Id == item.Stage_Id && e.Field_Id == item.Field_Id);
            _entities.Add(item);
        }

        public void Delete(int stageId, int fieldId)
        {
            _entities.RemoveAll(e => e.Stage_Id == stageId && e.Field_Id == fieldId);
        }
    }
}
