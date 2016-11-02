using System.Collections.Generic;
using System.Linq;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EFRepository;
using RecensysCoreRepository.EFRepository.Entities;
using RecensysCoreRepository.EFRepository.Repositories;
using Xunit;

namespace RecensysCoreRepository.Tests.Unittests
{
    public class TaskConfigRepositoryTests
    {

        [Fact]
        public void Create_1ArticleWith1Field__1task()
        {
            var options = Helpers.CreateInMemoryOptions();
            var context = new RecensysContext(options);
            var repo = new TaskConfigRepository(context);
            #region model
            var study = new Study
            {
                Stages = new List<Stage>
                {
                    new Stage
                    {
                        Id = 1,
                        StageFields = new List<StageFieldRelation>
                        {
                            new StageFieldRelation
                            {
                                FieldType = FieldType.Requested,
                                Field = new Field
                                {
                                    Id = 1,
                                    DataType = DataType.Boolean,
                                    Data = new List<Data>
                                    {
                                        new Data
                                        {
                                            Id = 1,
                                            Value = "d1",
                                            Article = new Article
                                            {
                                                Id = 2,
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                UserRelations = new List<UserStudyRelation>
                {
                    new UserStudyRelation
                    {
                        User = new User { Id = 1 }
                    }
                }
            };
            #endregion
            context.Studies.Add(study);
            context.SaveChanges();

            var dto = new ReviewTaskConfigDTO
            {
                ArticleId = 2,
                RequestedDataIds = new List<int>() { 1 },
                OwnerId = 1
            };

            using (repo)
            {
                var r = repo.Create(1, dto);

                Assert.Equal(1, context.Tasks.Count());
            }

        }


        [Fact]
        public void Create_1ArticleWith2Field__1task()
        {
            var options = Helpers.CreateInMemoryOptions();
            var context = new RecensysContext(options);
            var repo = new TaskConfigRepository(context);
            #region model
            var study = new Study
            {
                Stages = new List<Stage>
                {
                    new Stage
                    {
                        Id = 1,
                        StageFields = new List<StageFieldRelation>
                        {
                            new StageFieldRelation
                            {
                                FieldType = FieldType.Requested,
                                Field = new Field
                                {
                                    Id = 1,
                                    DataType = DataType.Boolean,
                                    Data = new List<Data>
                                    {
                                        new Data
                                        {
                                            Id = 1,
                                            Value = "d1",
                                            Article = new Article
                                            {
                                                Id = 2,
                                            }
                                        }
                                    }
                                }
                            },
                            new StageFieldRelation
                            {
                                FieldType = FieldType.Requested,
                                Field = new Field
                                {
                                    Id = 2,
                                    DataType = DataType.String,
                                    Data = new List<Data>
                                    {
                                        new Data
                                        {
                                            Id = 2,
                                            Value = "d2",
                                            ArticleId = 2
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                UserRelations = new List<UserStudyRelation>
                {
                    new UserStudyRelation
                    {
                        User = new User { Id = 1 }
                    }
                }
            };
            #endregion
            context.Studies.Add(study);
            context.SaveChanges();

            var dto = new ReviewTaskConfigDTO
            {
                ArticleId = 2,
                RequestedDataIds = new List<int>() { 1, 2 },
                OwnerId = 1
            };

            using (repo)
            {
                var r = repo.Create(1, dto);

                Assert.Equal(1, context.Tasks.Count());
            }

        }


        [Fact]
        public void Create_1ArticleWith2Fields__1TaskWith2Data()
        {
            var options = Helpers.CreateInMemoryOptions();
            var context = new RecensysContext(options);
            var repo = new TaskConfigRepository(context);
            #region model
            var study = new Study
            {
                Stages = new List<Stage>
                {
                    new Stage
                    {
                        Id = 1,
                        StageFields = new List<StageFieldRelation>
                        {
                            new StageFieldRelation
                            {
                                FieldType = FieldType.Requested,
                                Field = new Field
                                {
                                    Id = 1,
                                    DataType = DataType.Boolean,
                                    Data = new List<Data>
                                    {
                                        new Data
                                        {
                                            Id = 1,
                                            Value = "d1",
                                            Article = new Article
                                            {
                                                Id = 2,
                                            }
                                        }
                                    }
                                }
                            },
                            new StageFieldRelation
                            {
                                FieldType = FieldType.Requested,
                                Field = new Field
                                {
                                    Id = 2,
                                    DataType = DataType.String,
                                    Data = new List<Data>
                                    {
                                        new Data
                                        {
                                            Id = 2,
                                            Value = "d2",
                                            ArticleId = 2
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                UserRelations = new List<UserStudyRelation>
                {
                    new UserStudyRelation
                    {
                        User = new User { Id = 1 }
                    }
                }
            };
            #endregion
            context.Studies.Add(study);
            context.SaveChanges();

            var dto = new ReviewTaskConfigDTO
            {
                ArticleId = 2,
                RequestedDataIds = new List<int>() { 1, 2 },
                OwnerId = 1
            };

            using (repo)
            {
                var r = repo.Create(1, dto);

                var t = context.Tasks.Single(ta => ta.Id == r);

                Assert.Equal("d1", t.Data.Single(d1 => d1.Id == 1).Value);
                Assert.Equal("d2", t.Data.Single(d1 => d1.Id == 2).Value);
            }

        }


    }
}