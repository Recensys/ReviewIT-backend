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
    public class EFArticleRepositoryTests
    {

        [Fact]
        public void PreviousStage__correctlyIdentifiesPreviousStage()
        {
            var options = Helpers.CreateInMemoryOptions();
            var context = new RecensysContext(options);
            var repo = new EFArticleRepository(context);
            #region model
            var study = new Study
            {
                Id = 1,
                Stages = new List<Stage>
                {
                    new Stage {Id = 1},
                    new Stage {Id = 2},
                    new Stage {Id = 3},
                }
            };
            #endregion
            context.Studies.Add(study);
            context.SaveChanges();

            using (repo)
            {
                var r = repo.PreviousStage(2);

                Assert.Equal(1, r);
            }
        }

        
    }
}
