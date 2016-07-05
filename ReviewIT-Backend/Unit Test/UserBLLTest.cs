using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecensysBLL.BusinessLogicLayer;
using RecensysBLL.Models;
using RecensysBLL.Models.FullModels;
using RecensysRepository.Entities;
using RecensysRepository.Factory;

namespace Unit_Test
{
    [TestClass]
    public class UserBLLTest
    {
        [TestMethod]
        public void Add_ModelNotNull_Successful()
        {
            // Arrange
            var repo = new RepositoryFactoryMemory();
            var bll = new UserBLL(repo);
            var model = new UserModel();
            var precount = repo.GetUserRepo().GetAll().Count();

            // Act
            bll.Add(model);

            // Assert
            Assert.AreEqual(repo.GetUserRepo().GetAll().Count(), precount + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_ModelNull_ThrowNullException()
        {
            // Arrange
            var repo = new RepositoryFactoryMemory();
            var bll = new UserBLL(repo);

            // Act
            bll.Add(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_ModelIdOutofRange_ThrowsArgumentException()
        {
            // Arrange
            var repo = new RepositoryFactoryMemory();
            var bll = new UserBLL(repo);
            var model = new UserModel
            {
                Id = -1
            };

            // Act
            bll.Add(model);
        }

        [TestMethod]
        public void Get_ElementExists_Successful()
        {
            // Arrange
            var repo = new RepositoryFactoryMemory();
            var bll = new UserBLL(repo);
            repo.GetUserRepo().Create(new UserEntity
            {
                Id = 10,
                FirstName = "Mathias",
                LastName = "Pedersen"
            });

            // Act
            var model = bll.Get(10);

            // Assert
            Assert.AreEqual(model.Id, 10);
            Assert.AreEqual(model.FirstName, "Mathias");
            Assert.AreEqual(model.LastName, "Pedersen");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Get_NoSuchId_ThrowIndexOutOfRangeException()
        {
            // Arrange
            var repo = new RepositoryFactoryMemory();
            var bll = new UserBLL(repo);

            // Act
            var model = bll.Get(10);
        }

        [TestMethod]
        public void AssociateUserToStudy_GoodInput_Success()
        {
            // Arrange
            var repo = new RepositoryFactoryMemory();
            var bll = new UserBLL(repo);
            repo.GetUserRepo().Create(new UserEntity() {});

            // Act
            bll.AssociateUserToStudy(10, 15, 5);

            // Assert
            var storedDto = repo.GetUserStudyRelationRepo().Read(10, 15);
            Assert.AreEqual(storedDto.Id, 10);
            Assert.AreEqual(storedDto.Study_Id, 15);
            Assert.AreEqual(storedDto.StudyRole_Id, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AssociateUserTostudy_NonexistantUserId_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            var repo = new RepositoryFactoryMemory();
            var bll = new UserBLL(repo);
            repo.GetStudyRepo().Create(new StudyEntity() {Id = 15});
            repo.GetStudyRoleRepo().Create(new User_Study_RelationEntity() {Id = 5});

            // Act
            bll.AssociateUserToStudy(10, 15, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AssociateUserTostudy_NonexistantStudyId_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            var repo = new RepositoryFactoryMemory();
            var bll = new UserBLL(repo);
            repo.GetUserRepo().Create(new UserEntity() { Id = 10 });
            repo.GetStudyRoleRepo().Create(new User_Study_RelationEntity() { Id = 5 });

            // Act
            bll.AssociateUserToStudy(10, 15, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AssociateUserTostudy_NonexistantRoleId_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            var repo = new RepositoryFactoryMemory();
            var bll = new UserBLL(repo);
            repo.GetUserRepo().Create(new UserEntity() { Id = 10 });
            repo.GetStudyRepo().Create(new StudyEntity() { Id = 15 });

            // Act
            bll.AssociateUserToStudy(10, 15, 5);
        }

        [TestMethod]
        public void UnassociateUserToStudy_GoodInput_Success()
        {
            // Arrange
            var repo = new RepositoryFactoryMemory();
            var bll = new UserBLL(repo);
            repo.GetUserStudyRelationRepo().Create(new User_Stage_RelationEntity
            {
                Study_Id = 15,
                StudyRole_Id = 2,
                Id = 10
            });
            var count = repo.GetUserStudyRelationRepo().GetAll().Count();

            // Act
            bll.UnassociateUserToStudy(10, 15);

            // Assert
            Assert.AreEqual(count - 1, repo.GetUserStudyRelationRepo().GetAll().Count());
        }

        
    }
}