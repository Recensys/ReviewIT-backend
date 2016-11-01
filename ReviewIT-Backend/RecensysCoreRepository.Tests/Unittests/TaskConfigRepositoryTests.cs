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
        public void Create_1ArticleWith2Fields__2Data()
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
                                }
                            },
                            new StageFieldRelation
                            {
                                FieldType = FieldType.Requested,
                                Field = new Field
                                {
                                    Id = 3,
                                    DataType = DataType.String,
                                }
                            }
                        }
                    }
                },
                Articles = new List<Article>
                {
                    new Article
                    {
                        Id = 2,
                        StageArticleRelations = new List<StageArticleRelation>
                        {
                            new StageArticleRelation
                            {
                                StageId = 1
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
                RequestedFieldIds = new List<int>() {1, 3},
                OwnerId = 1
            };

            using (repo)
            {
                var r = repo.Create(1, dto);

                Assert.Equal(2, context.Data.Count());
            }

        }


        [Fact]
        public void Create_1ArticleWith2FieldsAnd2Data__4DataTotal()
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
                                }
                            },
                            new StageFieldRelation
                            {
                                FieldType = FieldType.Requested,
                                Field = new Field
                                {
                                    Id = 3,
                                    DataType = DataType.String,
                                }
                            }
                        }
                    }
                },
                Articles = new List<Article>
                {
                    new Article
                    {
                        Id = 2,
                        Data = new List<Data>
                        {
                            new Data {FieldId = 1},
                            new Data {FieldId = 1},
                        },
                        StageArticleRelations = new List<StageArticleRelation>
                        {
                            new StageArticleRelation
                            {
                                StageId = 1
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
                RequestedFieldIds = new List<int>() { 1, 3 },
                OwnerId = 1
            };

            using (repo)
            {
                var r = repo.Create(1, dto);

                Assert.Equal(4, context.Data.Count());
            }

        }

        [Fact]
        public void Create_1ArticleWith2Fields__4DataForParticularArticle()
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
                                }
                            },
                            new StageFieldRelation
                            {
                                FieldType = FieldType.Requested,
                                Field = new Field
                                {
                                    Id = 3,
                                    DataType = DataType.String,
                                }
                            }
                        },
                        StageArticleRelations = new List<StageArticleRelation>
                        {
                            new StageArticleRelation
                            {
                                Article = new Article
                                {
                                    Id = 6,
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
                ArticleId = 6,
                RequestedFieldIds = new List<int>() { 1, 3 },
                OwnerId = 1
            };

            using (repo)
            {
                var r = repo.Create(1, dto);

                var a = context.Articles.Single(ar => ar.Id == 6);

                Assert.Equal(2, a.Data.Count);
            }

        }


    }
}