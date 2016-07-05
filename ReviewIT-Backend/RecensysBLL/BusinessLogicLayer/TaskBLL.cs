using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using RecensysBLL.BusinessEntities;
using RecensysBLL.Models;
using RecensysBLL.Models.FullModels;
using RecensysRepository.Entities;
using RecensysRepository.Factory;
using TaskType = RecensysBLL.BusinessEntities.TaskType;

namespace RecensysBLL.BusinessLogicLayer
{
    public class TaskBLL
    {

        private readonly IRepositoryFactory _factory;

        public TaskBLL(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        public List<TaskModel> GetTasks(int stageId, int userId)
        {
            var tasks = new List<TaskModel>();
            
            using (var taskRepo = _factory.GetTaskRepo())
            using (var typeRepo = _factory.GetDataTypeRepo())
            using (var fieldDataRepo = _factory.GetDataRepo())
            {
                var taskDtos = taskRepo.GetAll().Where(dto => dto.User_Id == userId);
                foreach (var dto in taskDtos)
                {
                    var task = new TaskModel() {Id = dto.Id, Data = new List<DataModel>()};

                    // Add data to taskModel
                    var dataEntities = fieldDataRepo.GetAll().Where(d => d.Task_Id == dto.Id);
                    foreach (var dataEntity in dataEntities)
                    {
                        var dataType = typeRepo.Read(dataEntity.Field_Id);

                        task.Data.Add(new DataModel()
                        {
                            Id = dataEntity.Id,
                            Data = dataEntity.Value,
                            ArticleId = dataEntity.Article_Id,
                            DataType = dataType.Value,
                            DataTypeId = dataType.Id
                        });
                    }

                    tasks.Add(task);
                }
            }

            return tasks;
        }

        public void DeliverTask(ReviewTask task)
        {
            using (var dataRepo = _factory.GetDataRepo())
            {
                foreach (var data in task.Data)
                {
                    dataRepo.Update(new DataEntity()
                    {
                        Id = data.Id,
                        Value = data.Value
                    });
                }
            }

            using (var taskRepo = _factory.GetTaskRepo())
            {
                taskRepo.Update(new TaskEntity()
                {
                    Id = task.Id,
                    // TODO add done property do entity
                });
            }
            
        }

        public void DeliverTask(ValidationTask task)
        {
            throw new NotImplementedException();
        }

        public void CreateReviewTask(int? user, int stageId, int articleId, int[] fields)
        {
            int taskId;

            using (var taskRepo = _factory.GetTaskRepo())
            {
                taskId = taskRepo.Create(new TaskEntity()
                {
                    User_Id = user ?? -1,
                    Stage_Id = stageId,
                    Article_Id = articleId,
                    TaskType_Id = (int)TaskType.Review
                });
            }

            using (var dataRepo = _factory.GetDataRepo())
            {
                foreach (int field in fields)
                {
                    dataRepo.Create(new DataEntity()
                    {
                        Article_Id = articleId,
                        Field_Id = field,
                        Task_Id = taskId,
                    });
                }
            }
        }

        public void GenerateTasks(int stageId)
        {
            StrategyEntity reviewStrategies;
            StrategyEntity validationStrategies;

            using (var strRepo = _factory.GetStrategyRepo())
            {
                var strategies = strRepo.GetAll().Where(s => s.Stage_Id == stageId).ToList();
                reviewStrategies = strategies.Single(s => s.StrategyType_Id == (int) StrategyType.Review);
                validationStrategies = strategies.Single(s => s.StrategyType_Id == (int) StrategyType.Validation);
            }

            using (var )
            {
                
            }
            
        }

    }
}