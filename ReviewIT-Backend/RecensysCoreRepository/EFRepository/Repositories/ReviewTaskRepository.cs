using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EFRepository.Entities;
using RecensysCoreRepository.Repositories;

namespace RecensysCoreRepository.EFRepository.Repositories
{
    public class ReviewTaskRepository : IReviewTaskRepository
    {

        private readonly RecensysContext _context;

        public ReviewTaskRepository(RecensysContext context)
        {
            if (context == null) throw new ArgumentNullException($"{nameof(context)} is null");
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public ReviewTaskListDTO GetListDto(int stageId, int userId)
        {

            var fields = (from sf in _context.StageFieldRelations
                where sf.StageId == stageId
                orderby sf.FieldId
                let f = sf.Field
                select
                new TaskFieldDTO
                {
                    Id = f.Id,
                    Name = f.Name,
                    FieldType = sf.FieldType,
                    DataType = f.DataType
                }).ToList();
            
            var taskDtos = (from t in _context.Tasks
                              where t.StageId == stageId && t.UserId == userId
                              select new ReviewTaskDTO
                              {
                                  Id = t.Id,
                                  TaskState = 0,
                                  Data = (from d in _context.Data
                                          where d.TaskId == t.Id
                                         orderby d.FieldId
                                         select new DataDTO
                                         {
                                             Id = d.Id,
                                             Value = d.Value
                                         }).ToList()
                              }).ToList();

            var result = new ReviewTaskListDTO
            {
                Fields = fields,
                Tasks = taskDtos
            };

            return result;
        }

        public bool Update(ReviewTaskDTO dto)
        {
            var stored = (from t in _context.Tasks
                where t.Id == dto.Id
                select t).Single();

            stored.TaskState = dto.TaskState;

            foreach (var d in dto.Data)
            {
                var ds = _context.Data.Single(da => da.Id == d.Id);
                ds.Value = d.Value;
            }

            return _context.SaveChanges() > 0;
        }
    }
}
