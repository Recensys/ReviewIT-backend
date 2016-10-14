using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EFRepository.Entities;
using RecensysCoreRepository.Repositories;

namespace RecensysCoreRepository.EFRepository.Repositories
{
    public class TaskRepository: ITaskRepository
    {

        private readonly RecensysContext _context;

        public TaskRepository(RecensysContext context)
        {
            if (context == null) throw new ArgumentNullException($"{nameof(context)} is null");
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public int Create(int stageId, TaskDTO dto)
        {
            var task = new Entities.Task()
            {
                ArticleId = dto.ArticleId,
                StageId = stageId,
                UserId = dto.OwnerId,
                Data = new List<Data>()
            };
            foreach (var id in dto.DataIds)
            {
                var entity = _context.Data.Single(data => data.Id == id);
                task.Data.Add(entity);
            }

            _context.Tasks.Add(task);

            _context.SaveChanges();
            return task.Id;
        }
    }
}
