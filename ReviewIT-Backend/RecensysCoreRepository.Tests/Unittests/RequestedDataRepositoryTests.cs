using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.EFRepository;
using RecensysCoreRepository.EFRepository.Entities;
using RecensysCoreRepository.EFRepository.Repositories;
using Xunit;

namespace RecensysCoreRepository.Tests.Unittests
{
    public class RequestedDataRepositoryTests
    {
        
        [Fact]
        public void GetAll_stage_with_requested_data__returns_dataId()
        {
            var options = Helpers.CreateInMemoryOptions();
            var context = new RecensysContext(options);
            var repo = new RequestedDataRepository(context);
            #region model

            var study = new Study
            {
                Id = 1,
                Stages = new List<Stage>
                {
                    new Stage
                    {
                        Id = 1,
                        Strategies = new List<Strategy>
                        {
                            new Strategy
                            {
                                StrategyType = StrategyType.Distribution,
                                Value = ""
                            }
                        },
                        Inclusions = new List<Inclusion>
                        {
                            new Inclusion
                            {
                                Article = new Article
                                {
                                    Data = new List<Data>
                                    {
                                        new Data
                                        {
                                            Field = new Field
                                            {
                                                Id = 1,
                                                Name = "isGSD?",
                                                StageFields = new List<StageFieldRelation>
                                                {
                                                    new StageFieldRelation
                                                    {
                                                        FieldType = FieldType.Requested
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

                Assert.Equal(1, r.Single().DataIds.Single());
            }
        }

        [Fact]
        public void GetAll_stage_only_with_visible_data__no_data()
        {
            var options = Helpers.CreateInMemoryOptions();
            var context = new RecensysContext(options);
            var repo = new RequestedDataRepository(context);
            #region model
            var study = new Study
            {
                Id = 1,
                Stages = new List<Stage>
                {
                    new Stage
                    {
                        Id = 1,
                        Strategies = new List<Strategy>
                        {
                            new Strategy
                            {
                                StrategyType = StrategyType.Distribution,
                                Value = ""
                            }
                        },
                        Inclusions = new List<Inclusion>
                        {
                            new Inclusion
                            {
                                Article = new Article
                                {
                                    Data = new List<Data>
                                    {
                                        new Data
                                        {
                                            Field = new Field
                                            {
                                                Id = 1,
                                                Name = "isGSD?",
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
                }
            };
            #endregion
            context.Studies.Add(study);
            context.SaveChanges();

            using (repo)
            {
                var r = repo.GetAll(1);

                Assert.Equal(0, r.First().DataIds.Count);
            }
        }


    }
}
