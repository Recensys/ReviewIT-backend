using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EFRepository;
using RecensysCoreRepository.EFRepository.Entities;
using RecensysCoreRepository.EFRepository.Repositories;
using Xunit;

namespace RecensysCoreRepository.Tests.Unittests
{
    public class RequestedDataRepositoryTests
    {
        
        [Fact]
        public void GetAll_stageWith1RequestedField__1RequestedField()
        {
            var options = Helpers.CreateInMemoryOptions();
            var context = new RecensysContext(options);
            var repo = new RequestedFieldsRepository(context);
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
                                    Data = new List<Data>
                                    {
                                        new Data
                                        {
                                            Id = 1,
                                            Article = new Article
                                            {
                                                StageArticleRelations = new List<StageArticleRelation>
                                                {
                                                    new StageArticleRelation
                                                    {
                                                        StageId = 1,
                                                    }
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
                var r = repo.GetAll(1);
                Assert.Equal(1, r.First().FieldIds.Count());
            }
        }

        [Fact]
        public void GetAll_stageWith1VisibleField__0RequestedField()
        {
            var options = Helpers.CreateInMemoryOptions();
            var context = new RecensysContext(options);
            var repo = new RequestedFieldsRepository(context);
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
                                FieldType = FieldType.Visible,
                                Field = new Field
                                {
                                    Data = new List<Data>
                                    {
                                        new Data
                                        {
                                            Id = 1,
                                            Article = new Article
                                            {
                                                StageArticleRelations = new List<StageArticleRelation>
                                                {
                                                    new StageArticleRelation
                                                    {
                                                        StageId = 1,
                                                    }
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
                var r = repo.GetAll(1);
                Assert.Equal(0, r.First().FieldIds.Count());
            }
        }
        


    }
}
