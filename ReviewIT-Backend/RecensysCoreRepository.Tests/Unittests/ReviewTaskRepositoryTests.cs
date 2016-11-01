using System.Collections.Generic;
using System.Linq;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EFRepository;
using RecensysCoreRepository.EFRepository.Entities;
using RecensysCoreRepository.EFRepository.Repositories;
using Xunit;

namespace RecensysCoreRepository.Tests.Unittests
{
    public class ReviewTaskRepositoryTests
    {


        [Fact]
        public void GetListDto_1taskWith1Data_1ReviewTask()
        {
            var options = Helpers.CreateInMemoryOptions();
            var context = new RecensysContext(options);
            var repo = new ReviewTaskRepository(context);
            #region model

            var study = new Study
            {
                Id = 1,
                Stages = new List<Stage>
                {
                    new Stage
                    {
                        Id = 1,
                        Tasks = new List<Task>
                        {
                            new Task
                            {
                                Id = 1,
                                TaskType = TaskType.Review,
                                User = new User {Id = 1},
                                Data = new List<Data>
                                {
                                    new Data
                                    {
                                        Id = 1,
                                        Field = new Field
                                        {
                                            DataType = DataType.Boolean,
                                            StageFields = new List<StageFieldRelation>
                                            {
                                                new StageFieldRelation
                                                {
                                                    FieldType = FieldType.Visible
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            #endregion
            context.Studies.Add(study);
            context.SaveChanges();

            using (repo)
            {
                var r = repo.GetListDto(1, 1);

                Assert.Equal(1, r.Tasks.Count);
            }
        }


        [Fact]
        public void GetListDto__FieldsAndDataOrderedCorrectly()
        {
            var options = Helpers.CreateInMemoryOptions();
            var context = new RecensysContext(options);
            var repo = new ReviewTaskRepository(context);
            #region model

            var d1 = new Data { Id = 1, Field = new Field { Id = 3 } };
            var d2 = new Data { Id = 2, Field = new Field { Id = 2 } };
            var d3 = new Data { Id = 3, Field = new Field { Id = 1 } };
            context.Data.AddRange(d1,d2,d3);
            context.SaveChanges();
            var study = new Study
            {
                Id = 1,
                Stages = new List<Stage>
                {
                    new Stage
                    {
                        Id = 1,
                        StageFields = new List<StageFieldRelation>
                        {
                            new StageFieldRelation{FieldId = 1},
                            new StageFieldRelation{FieldId = 2},
                            new StageFieldRelation{FieldId = 3}
                        },
                        Tasks = new List<Task>
                        {
                            new Task
                            {
                                Id = 1,
                                TaskType = TaskType.Review,
                                User = new User { Id = 1 },
                                Data = new List<Data> { d1,d2,d3 }
                            }
                        }
                    }
                }
            };
            #endregion
            context.Studies.Add(study);
            context.SaveChanges();

            using (repo)
            {
                var r = repo.GetListDto(1, 1);
                var firstData = r.Tasks.First().Data.First();

                Assert.Equal(context.Data.First(d => d.Id == firstData.Id).FieldId, r.Fields.First().Id);
            }
        }


    }
}