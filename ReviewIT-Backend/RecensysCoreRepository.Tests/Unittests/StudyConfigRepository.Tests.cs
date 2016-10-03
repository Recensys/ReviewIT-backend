using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Moq;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EF;
using RecensysCoreRepository.Entities;
using RecensysCoreRepository.Repositories;
using Xunit;

namespace RecensysCoreRepository.Tests.Unittests
{
    public class StudyConfigRepositoryTests
    {
        [Fact]
        public void Create_returns_new_id()
        {
            var options = Helpers.CreateInMemoryOptions();
			var context = new RecensysContext(options);
            var repo = new StudyConfigRepository(context);
            var dto = new StudyConfigDTO();


            using (repo)
            {
                var id = repo.Create(dto);

				Assert.Equal(1,id);
            }
        }

        [Fact]
        public void Create_calls_saveChanges_on_context()
        {
            var mock = new Mock<IRecensysContext>();
            mock.Setup(m => m.Studies.Add(It.IsAny<Study>()));
            var repo = new StudyConfigRepository(mock.Object);
            var dto = new StudyConfigDTO();

            using (repo)
            {
                var id = repo.Create(dto);
            }

			mock.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void Read_id_returnes_study_with_id()
        {
            var options = Helpers.CreateInMemoryOptions();
            var context = new RecensysContext(options);
            var repo = new StudyConfigRepository(context);
            context.Studies.Add(new Study() {Id = 1, Name = "Name", Description = "Desc"});
            context.Studies.Add(new Study() {Id = 2, Name = "Name2", Description = "Desc"});
            context.SaveChanges();

            using (repo)
            {
                var dto = repo.Read(2);

				Assert.Equal("Name2", dto.Name);
				Assert.Equal("Desc", dto.Description);
				Assert.Equal(2, dto.Id);
            }
        }

        [Fact]
        public void Update_dto_with_name_repo_updated_correctly()
        {
            var options = Helpers.CreateInMemoryOptions();
            var context = new RecensysContext(options);
            var repo = new StudyConfigRepository(context);
            var entity = new Study() {Id = 1, Name = "", Description = "Desc"};
            context.Studies.Add(entity);
            context.SaveChanges();

            using (repo)
            {
                var dto = new StudyConfigDTO() {Id = 1, Name = "Name"};

                repo.Update(dto);

                Assert.Equal("Name", entity.Name);
            }
        }

        [Fact]
        public void Delete_stored_item_with_id_1_removed()
        {
            var options = Helpers.CreateInMemoryOptions();
            var context = new RecensysContext(options);
            var repo = new StudyConfigRepository(context);
            var entity = new Study() { Id = 1, Name = "", Description = "Desc" };
            context.Studies.Add(entity);
            context.SaveChanges();

            using (repo)
            {
                var dto = new StudyConfigDTO() {Id = 1};
                repo.Delete(dto);

                Assert.True(context.Studies.Count(s => s.Id == 1)==0);
            }
        }
    }	
}
