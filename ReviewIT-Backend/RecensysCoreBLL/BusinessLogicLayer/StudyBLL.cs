using System;
using System.Collections.Generic;
using RecensysCoreRepository;
using StudyEntity = RecensysCoreRepository.Entities.Study;
using RecensysCoreBLL.BusinessEntities;
using RecensysCoreBLL.BusinessEntities.OverviewEntities;

namespace RecensysCoreBLL.BusinessLogicLayer
{
    public class StudyBLL
    {

        private readonly IRepositoryFactory _factory;

        public StudyBLL(IRepositoryFactory factory)
        {
            _factory = factory;
        }


        public List<StudyDetails> Get()
        {
            var studies = new List<StudyDetails>();

            using (var studyRepo = _factory.GetRepo<StudyEntity>())
            {
                var studyEntities = studyRepo.GetAll();
                //TODO check user relation to studies
                foreach (var studyEntity in studyEntities)
                {
                    studies.Add(new StudyDetails()
                    {
                        Id = studyEntity.Id,
                        Name = studyEntity.Title,
                        Description = studyEntity.Description
                    });
                }
            }

            return studies;
        }
        

        public int AddStudy()
        {
            using (var srepo = _factory.GetRepo<StudyEntity>())
            {
                return srepo.Create(new StudyEntity());
            }
        }

        

    }
}