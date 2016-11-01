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

            var taskList = new ReviewTaskListDTO {};

            var fields = (from sf in _context.StageFieldRelations
                where sf.StageId == stageId
                orderby sf.FieldId
                select new { Field = new FieldDTO {Id = sf.Field.Id, Name = sf.Field.Name, DataType = sf.Field.DataType}, sf.FieldType }).ToList();

            var taskDtos = (from t in _context.Tasks
                              where t.StageId == stageId && t.UserId == userId
                              select new ReviewTaskDTO
                              {
                                  Id = t.Id,
                                  TaskState = 0,
                                  Data = (from d in t.Data
                                         join f in fields on d.FieldId equals f.Field.Id
                                         orderby f.Field.Id
                                         select new DataDTO
                                         {
                                             Id = d.Id,
                                             Value = d.Value
                                         }).ToList()
                              }).ToList();

            var result = new ReviewTaskListDTO
            {
                Fields = fields.Select(f => f.Field).ToList(),
                Tasks = taskDtos
            };

            return result;
        }
    }
}
