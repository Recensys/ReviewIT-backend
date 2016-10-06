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
                repo.Delete(1);

                Assert.True(context.Studies.Count(s => s.Id == 1)==0);
            }
        }

        [Fact]
        public void Update_new_subentity_added()
        {
            var options = Helpers.CreateInMemoryOptions();
            var context = new RecensysContext(options);
            var repo = new StudyConfigRepository(context);
            var entity = new Study() { Id = 1, Name = "", Description = "Desc" };
            context.Studies.Add(entity);
            context.SaveChanges();

            using (repo)
            {
                var dto = new StudyConfigDTO()
                {
                    Id = 1,
                    Stages = new List<StageConfigDTO>()
                    {
                        new StageConfigDTO() {Id = -1, Name = "S1"}
                    }
                };

                repo.Update(dto);

                Assert.Equal(1, entity.Stages.Count);
            }
        }

        [Fact]
        public void Update_zero_stages_passed_removes_stored_stages()
        {
            var options = Helpers.CreateInMemoryOptions();
            var context = new RecensysContext(options);
            var repo = new StudyConfigRepository(context);
            var entity = new Study() { Id = 1, Name = "", Description = "Desc", Stages = new List<Stage>() {new Stage() {Name = "S1"} } };
            context.Studies.Add(entity);
            context.SaveChanges();

            using (repo)
            {
                var dto = new StudyConfigDTO()
                {
                    Id = 1
                };

                repo.Update(dto);

                Assert.Equal(0, entity.Stages.Count);
            }

        }

        [Fact]
        public void Update_one_stage_passed_with_id_0_one_two_stages_stored__stored_stages_removed()
        {
            var options = Helpers.CreateInMemoryOptions();
            var context = new RecensysContext(options);
            var repo = new StudyConfigRepository(context);
            var entity = new Study() { Id = 1, Name = "", Description = "Desc", Stages = new List<Stage>() { new Stage() { Name = "S1" }, new Stage() { Name = "S2" } } };
            context.Studies.Add(entity);
            context.SaveChanges();

            using (repo)
            {
                var dto = new StudyConfigDTO()
                {
                    Id = 1,
                    Stages = new List<StageConfigDTO>() { new StageConfigDTO() { Name = "S3"} }
                };

                repo.Update(dto);

                Assert.Equal(1, entity.Stages.Count);
                Assert.True(entity.Stages.Count(s => s.Name == "S3") == 1);
            }

        }

        [Fact]
        public void Update_one_stage_passed_with_id_0_zero_stages_stored__passed_stage_stored()
        {
            var options = Helpers.CreateInMemoryOptions();
            var context = new RecensysContext(options);
            var repo = new StudyConfigRepository(context);
            var entity = new Study() { Id = 1, Name = "", Description = "Desc" };
            context.Studies.Add(entity);
            context.SaveChanges();

            using (repo)
            {
                var dto = new StudyConfigDTO()
                {
                    Id = 1,
                    Stages = new List<StageConfigDTO>() { new StageConfigDTO() { Name = "S1" } }
                };

                repo.Update(dto);

                Assert.Equal(1, entity.Stages.Count);
                Assert.True(entity.Stages.Count(s => s.Name == "S1") == 1);
            }

        }

        [Fact]
        public void Update_passed_one_stage_not_stored_removed_other_stage()
        {
            var options = Helpers.CreateInMemoryOptions();
            var context = new RecensysContext(options);
            var repo = new StudyConfigRepository(context);
            var stage = new Stage() {Name = "S1"};
            var entity = new Study() { Id = 0, Name = "", Description = "Desc", Stages = new List<Stage>() { stage } };
            context.Studies.Add(entity);
            context.SaveChanges();

            using (repo)
            {
                var dto = new StudyConfigDTO()
                {
                    Id = 1,
                    Stages = new List<StageConfigDTO>() { new StageConfigDTO() { Name = "S2"} }
                };

                repo.Update(dto);

                Assert.Equal(1, entity.Stages.Count(s => s.Name == "S2"));
                Assert.Equal(1, entity.Stages.Count);
            }

        }
    }	
}
