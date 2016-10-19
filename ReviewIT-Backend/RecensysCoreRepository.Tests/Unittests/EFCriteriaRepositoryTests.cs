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
    public class EFCriteriaRepositoryTests
    {
        [Fact]
        public void Update_one_inclusion_stored_one_exclusion_passed__one_exclusion_stored()
        {
            var options = Helpers.CreateInMemoryOptions();
            var context = new RecensysContext(options);
            var repo = new EFCriteriaRepository(context);
            #region model

            var study = new Study
            {
                Id = 1,
                Criteria = new List<Criteria>
                {
                    new Criteria
                    {
                        Id = 1,
                        Field = new Field { },
                        Type = CriteriaType.Inclusion,
                        
                    }
                }
            };
            #endregion
            context.Studies.Add(study);
            context.SaveChanges();
            var dto = new CriteriaDTO
            {
                Exclusions = new List<FieldCriteriaDTO> { new FieldCriteriaDTO {Field = new FieldDTO()} }
            };

            using (repo)
            {
                var r = repo.Update(1, dto);

                Assert.Equal(1, context.Criterias.Count(c => c.Type == CriteriaType.Exclusion));
                Assert.Equal(0, context.Criterias.Count(c => c.Type == CriteriaType.Inclusion));
            }
        }
    }
}
