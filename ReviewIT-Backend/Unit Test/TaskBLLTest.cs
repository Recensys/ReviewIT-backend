/*

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecensysBLL.BusinessLogicLayer;
using RecensysRepository.Entities;
using RecensysRepository.Factory;

namespace Unit_Test
{
    [TestClass]
    public class TaskBLLTest
    {
        [TestMethod]
        public void GetTasks_TwoTasksStored_TwoTasksReturned()
        {
            // Arrange
            var repo = new RepositoryFactoryMemory();
            var bll = new TaskBLL(repo);
            repo.GetTaskRepo().Create(new TaskEntity()
            {
                Id = 1,
                Stage_Id = 1,
                TaskType_Id = 1,
                User_Id = 1,
            });
            repo.GetTaskRepo().Create(new TaskEntity()
            {
                Id = 2,
                Stage_Id = 1,
                TaskType_Id = 1,
                User_Id = 1,
            });


            // Act
            var tasks = bll.GetTasks(1, 1);

            // Assert
            Assert.AreEqual(2,tasks.Count);
        }

        [TestMethod]
        public void GetTasks_ZeroTasksStored_ZeroTasksReturned()
        {
            // Arrange
            var repo = new RepositoryFactoryMemory();
            var bll = new TaskBLL(repo);

            // Act
            var tasks = bll.GetTasks(1, 1);

            // Assert
            Assert.AreEqual(0,tasks.Count);
        }

        [TestMethod]
        public void GetTasks_TaskHasData_DataReturned()
        {
            // Arrange
            var repo = new RepositoryFactoryMemory();
            var bll = new TaskBLL(repo);
            repo.GetTaskRepo().Create(new TaskEntity()
            {
                Id = 1,
                Stage_Id = 1,
                TaskType_Id = 1,
                User_Id = 1,
            });
            repo.GetFieldRepo().Create(new FieldEntity()
            {
                Id = 3,
                Name = "TestField"
            });
            repo.GetDataRepo().Create(new DataEntity()
            {
                Id = 2,
                Field_Id = 3,
                Value = "TestData",
                Task_Id = 1
            });

            // Act
            var task = bll.GetTasks(1, 1).Single();

            // Assert
            Assert.AreEqual("TestField", task.DataDictionary.First().Key);
            Assert.AreEqual("TestData", task.DataDictionary.First().Value);
        }

        [TestMethod]
        public void GetTasks_HasTwoFieldsWithData_DataReturned()
        {
            // Arrange
            var repo = new RepositoryFactoryMemory();
            var bll = new TaskBLL(repo);
            repo.GetTaskRepo().Create(new TaskEntity()
            {
                Id = 1,
                Stage_Id = 1,
                TaskType_Id = 1,
                User_Id = 1,
            });
            repo.GetFieldRepo().Create(new FieldEntity()
            {
                Id = 1,
                Name = "TestField"
            });
            repo.GetFieldRepo().Create(new FieldEntity()
            {
                Id = 2,
                Name = "TestField2"
            });
            repo.GetDataRepo().Create(new DataEntity()
            {
                Id = 2,
                Field_Id = 1,
                Value = "TestData",
                Task_Id = 1
            });
            repo.GetDataRepo().Create(new DataEntity()
            {
                Id = 3,
                Field_Id = 2,
                Value = "TestData",
                Task_Id = 1
            });
            

            // Act
            var task = bll.GetTasks(1, 1).Single();

            // Assert
            Assert.AreEqual(2, task.DataDictionary.Count);
            Assert.AreEqual("TestData", task.DataDictionary.First().Value);
        }

        [TestMethod]
        public void GenerateTasks_StageIdWithStrategyToCreateTwoTasks_TwoTasksCreated()
        {
            // Arrange
            var repo = new RepositoryFactoryMemory();
            var bll = new TaskBLL(repo);
            repo.GetStageRepo().Create(new StageEntity()
            {
                Id = 1,
            });
            repo.GetUserRepo().Create(new UserEntity()
            {
                Id = 1,
            });
            repo.GetStrategyRepo().Create(new StrategyEntity()
            {
                Id = 1,
                Stage_Id = 1,
                Value = "",
                StrategyType_Id = 0
            });
            
            // Act
            bll.GenerateTasks(1);
            var tasks = bll.GetTasks(1, 1);

            // Assert
            Assert.AreEqual(5, tasks.Count);
        }

        
    }
}

*/