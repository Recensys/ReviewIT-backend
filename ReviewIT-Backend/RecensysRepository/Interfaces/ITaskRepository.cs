using System;
using System.Collections.Generic;
using RecensysRepository.Entities;

namespace RecensysRepository.Interfaces
{
    public interface ITaskRepository : IDisposable
    {
        IEnumerable<TaskEntity> GetAll();

        int Create(TaskEntity item);

        TaskEntity Read(int id);

        void Update(TaskEntity item);

        void Delete(int id);
    }
}
