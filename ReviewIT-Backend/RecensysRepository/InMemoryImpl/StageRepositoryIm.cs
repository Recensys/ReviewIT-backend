using System.Collections.Generic;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    public class StageRepositoryIm : IStageRepository
    {

        private List<StageEntity> _stages = new List<StageEntity>()
        {
        };

        public void Dispose()
        {
        }

        public IEnumerable<StageEntity> GetAll()
        {
            return _stages;
        }

        public int Create(StageEntity item)
        {
            _stages.Add(item);
            item.Id = _stages.IndexOf(item);
            return item.Id;
        }

        public StageEntity Read(int id)
        {
            return _stages.Find(dto => dto.Id == id);
        }

        public void Update(StageEntity item)
        {
            _stages.RemoveAll(dto => dto.Id == item.Id);
            _stages.Add(item);
        }

        public void Delete(int id)
        {
            _stages.RemoveAll(dto => dto.Id == id);
        }
    }
}