using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;
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
            var taskList = new ReviewTaskListDTO();

            var fields = (from sf in _context.StageFieldRelations
                where sf.StageId == stageId
                select new FieldDTO
                {
                    Id = sf.Field.Id,
                    Name = sf.Field.Name,
                    DataType = sf.Field.DataType
                }).ToList();
            var tasksNoData = (from t in _context.Tasks
                              where t.StageId == stageId && t.UserId == userId
                              select new ReviewTaskDTO
                              {
                                  Id = t.Id,
                                  TaskState = 0,
                                  Data = new List<DataDTO>()
                              }).ToList();

            foreach (var fieldDto in fields)
            {
                foreach (var reviewTaskDto in tasksNoData)
                {
                    var data = from d in _context.Data
                        where d.FieldId == fieldDto.Id && d.TaskId == reviewTaskDto.Id
                        select new DataDTO
                        {
                            Id = d.Id,
                            Value = d.Value
                        };
                    reviewTaskDto.Data.Add(data.First());
                }
            }

            taskList.Fields = fields;
            taskList.Tasks = tasksNoData;

            return taskList;
        }
    }
}
