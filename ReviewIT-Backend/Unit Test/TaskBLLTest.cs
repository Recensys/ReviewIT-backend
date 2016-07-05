using System;
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
        public void GetTasks_checkTaskInfo_Correct()
        {
            // Arrange
            var repo = new RepositoryFactoryMemory();
            var bll = new TaskBLL(repo);
            repo.GetTaskRepo().Create(new TaskEntity()
            {
                
            });

            // Act

            // Assert

        }
    }
}
