using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using RecensysBLL.BusinessEntities;
using RecensysCoreRepository.Factory;
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

        public List<Task> GetTasks(int stageId, int userId)
        {
            var tasks = new List<Task>();

            // GetDetails tasks
            using (var taskRepo = _factory.GetTaskRepo())
            using (var dataRepo = _factory.GetDataRepo())
            {
                var taskEntities = taskRepo.GetAll().Where(t => t.User_Id == userId && t.Stage_Id == stageId);
                foreach (var taskEntity in taskEntities)
                {
                    var dataEntities = dataRepo.GetAll().Where(d => d.Task_Id == taskEntity.Id);
                    var data = new List<Data>();
                    foreach (var dataEntity in dataEntities)
                    {
                        data.Add(new Data()
                        {
                            Id = dataEntity.Id,
                            Value = dataEntity.Value
                        });
                    }
                    tasks.Add(new Task()
                    {
                        Id = taskEntity.Id,
                        Data = data,
                        TaskState = TaskState.New
                    });
                }
            }

            /*

            // Build data dictionary and create tasks for return
            using (var dataRepo = _factory.GetDataRepo())
            using (var fieldRepo = _factory.GetFieldRepo())
            {
                foreach (var taskEntity in taskEntities)
                {
                    var task = new Task
                    {
                        Id = taskEntity.Id,
                        DataDictionary = new Dictionary<string, string>()
                    };

                    var dataEntities = dataRepo.GetAll().Where(t => t.Task_Id == taskEntity.Id);

                    foreach (var dataEntity in dataEntities)
                    {
                        var fieldName = fieldRepo.Read(dataEntity.Field_Id).Name;

                        task.DataDictionary.Add(fieldName, dataEntity.Value);
                    }

                    tasks.Add(task);
                }
            }*/
            
            return tasks;
        }

        public void DeliverTask(ReviewTask task)
        {
            /*
            using (var dataRepo = _factory.GetDataRepo())
            {
                foreach (var data in task)
                {
                    dataRepo.Update(new DataEntity()
                    {
                        Id = data.Id,
                        Value = data.Value
                    });
                }
            }*/

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

        private void CreateReviewTask(int? userId, int stageId, int articleId, List<int> fields)
        {
            int taskId;

            using (var taskRepo = _factory.GetTaskRepo())
            {
                taskId = taskRepo.Create(new TaskEntity()
                {
                    User_Id = userId ?? -1,
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

        private void CreateValidationTask(int? userId, int stageId, int articleId, List<int> fields)
        {
            int taskId;

            using (var taskRepo = _factory.GetTaskRepo())
            {
                taskId = taskRepo.Create(new TaskEntity()
                {
                    User_Id = userId ?? -1,
                    Stage_Id = stageId,
                    Article_Id = articleId,
                    TaskType_Id = (int)TaskType.Validation
                });
            }

            AssociateTasksToParent(articleId, taskId);
        }

        private void AssociateTasksToParent(int articleId, int parentId)
        {
            using (var taskRepo = _factory.GetTaskRepo())
            {
                var tasks = taskRepo.GetAll().Where(e => e.Article_Id == articleId);
                foreach (var task in tasks)
                {
                    task.Parent_Id = parentId;
                    taskRepo.Update(task);
                }
            }
        }

        public int GenerateTasks(int stageId)
        {
            // GetDetails articles
            var articleIds = new List<int>();
            using (var articleRepo = _factory.GetArticleRepo())
            {
                var articles = articleRepo.GetAll();
                foreach (var article in articles)
                {
                    articleIds.Add(article.Id);
                }
            }

            // GetDetails the task distribution
            var reviewDictionary = new StrategyBLL(_factory).GetReviewtaskDistribution(stageId, articleIds);

            // GetDetails the stage description, ie. the fields related to the stage
            var fieldIds = new List<int>();
            using (var stageDescRepo = _factory.GetStageFieldsRepository())
            {
                var stageDescriptionEntities = stageDescRepo.GetAll().Where(e => e.Stage_Id == stageId);
                foreach (var entity in stageDescriptionEntities)
                {
                    fieldIds.Add(entity.Field_Id);
                }
            }

            // create the review tasks
            foreach (var entry in reviewDictionary)
            {
                foreach (var articleId in entry.Value)
                {
                    CreateReviewTask(entry.Key, stageId, articleId, fieldIds);
                }
            }

            //TODO create the validation tasks
            // TODO return nr of created tasks
            return 0;
        }

    }
}