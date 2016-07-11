using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecensysBLL.BusinessLogicLayer;
using RecensysBLL.Models.OverviewModels;
using RecensysRepository.Entities;
using RecensysRepository.Factory;

namespace Unit_Test
{
    [TestClass]
    public class StudyBLLTest
    {
        [TestMethod]
        public void AddNew_GoodInput_Successful()
        {
            // Arrange
            var repo = new RepositoryFactoryMemory();
            var bll = new StudyBLL(repo);
            var model = new StudyOverviewModel
            {
                Id = 10,
                Name = "name",
                Description = "desc"
            };
            var count = repo.GetStudyRepo().GetAll().Count();

            // Act
            bll.AddNew(model);

            // Assert
            Assert.AreEqual(count + 1, repo.GetStudyRepo().GetAll().Count());
        }

        [TestMethod]
        public void Get__Successful()
        {
            // Arrange
            var repo = new RepositoryFactoryMemory();
            var bll = new StudyBLL(repo);
            var model = new StudyOverviewModel
            {
                Id = 10,
                Name = "name",
                Description = "desc"
            };
            var count = repo.GetStudyRepo().GetAll().Count();

            // Act
            var list = bll.Get();

            // Assert
            Assert.AreEqual(count, list.Count);
        }




        [TestMethod]
        public void Remove_GoodId_Successful()
        {
            // Arrange
            var repo = new RepositoryFactoryMemory();
            var bll = new StudyBLL(repo);
            repo.GetStudyRepo().Create(new StudyEntity
            {
                Id = 13
            });
            var count = repo.GetStudyRepo().GetAll().Count();

            // Act
            bll.Remove(13);

            // Assert
            Assert.AreEqual(count - 1, repo.GetStudyRepo().GetAll().Count());
        }

        [TestMethod]
        public void AddStage_GoodInput_StageAdded()
        {
            // Arrange
            var repo = new RepositoryFactoryMemory();
            var bll = new StudyBLL(repo);
        }
    }
}