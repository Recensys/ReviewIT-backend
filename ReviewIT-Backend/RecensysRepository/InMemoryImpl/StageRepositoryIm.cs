using System.Collections.Generic;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    public class StageRepositoryIm : IStageRepository
    {

        private List<StageEntity> _stages = new List<StageEntity>()
        {
            new StageEntity() {Id = 1, Name = "Stage 1", Description = "Description for stage 1", InProgress = true, Study_Id = 1, Strategy_Id = 1},
            new StageEntity() {Id = 2, Name = "Stage 2", Description = "Description for stage 2", InProgress = false, Study_Id = 1, Strategy_Id = 1}
        };

        public void Dispose()
        {
        }

        public IEnumerable<StageEntity> GetAll()
        {
            return _stages;
        }

        public void Create(StageEntity item)
        {
            _stages.Add(item);
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