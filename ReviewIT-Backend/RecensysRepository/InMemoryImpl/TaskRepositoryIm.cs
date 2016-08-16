using System.Collections.Generic;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    public class TaskRepositoryIm : ITaskRepository
    {

        private List<TaskEntity> _tasks = new List<TaskEntity>()
        {
            new TaskEntity() {Id = 0, Article_Id = 0, Stage_Id = 0, User_Id = 0},
            new TaskEntity() {Id = 1, Article_Id = 1, Stage_Id = 0, User_Id = 0},
            new TaskEntity() {Id = 2, Article_Id = 2, Stage_Id = 0, User_Id = 0},
        };

        public void Dispose()
        {
        }

        public IEnumerable<TaskEntity> GetAll()
        {
            return _tasks;
        }

        public int Create(TaskEntity item)
        {
            _tasks.Add(item);
            return _tasks.IndexOf(item);
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