using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EFRepository.Entities;
using RecensysCoreRepository.Repositories;

namespace RecensysCoreRepository.EFRepository.Repositories
{
    public class TaskConfigRepository: ITaskConfigRepository
    {

        private readonly RecensysContext _context;

        public TaskConfigRepository(RecensysContext context)
        {
            if (context == null) throw new ArgumentNullException($"{nameof(context)} is null");
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public int Create(int stageId, ReviewTaskConfigDTO configDto)
        {
            var task = new Entities.Task
            {
                ArticleId = configDto.ArticleId,
                StageId = stageId,
                UserId = configDto.OwnerId,
                TaskType = TaskType.Review,
                Data = (from fid in configDto.RequestedFieldIds
                       select new Data
                       {
                           ArticleId = configDto.ArticleId,
                           FieldId = fid,
                       }).ToList()
            };

            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task.Id;
        }
    }
}
