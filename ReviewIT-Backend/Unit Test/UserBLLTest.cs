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

        

        
    }
}