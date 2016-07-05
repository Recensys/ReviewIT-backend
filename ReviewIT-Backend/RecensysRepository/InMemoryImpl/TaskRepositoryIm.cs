using System.Collections.Generic;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    public class TaskRepositoryIm : ITaskRepository
    {

        private List<TaskEntity> _tasks = new List<TaskEntity>();

        public void Dispose()
        {
        }

        public IEnumerable<TaskEntity> GetAll()
        {
            return _tasks;
        }

        public void Create(TaskEntity item)
        {
            _tasks.Add(item);
        }

        public TaskEntity Read(int id)
        {
            return _tasks.Find(dto => dto.Id == id);
        }

        public void Update(TaskEntity item)
        {
            _tasks.RemoveAll(dto => dto.Id == item.Id);
            _tasks.Add(item);
        }

        public void Delete(int id)
        {
            _tasks.RemoveAll(dto => dto.Id == id);
        }
    }
}