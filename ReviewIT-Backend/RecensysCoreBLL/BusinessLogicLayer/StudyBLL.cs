using System;
using System.Collections.Generic;
using System.Linq;
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
                        StudyId = studyEntity.Id,
                        Name = studyEntity.Name,
                        Description = studyEntity.Description
                    });
                }
            }

            return studies;
        }
        

        public int Create(Study s)
        {

            var sEntity = EntityMapper.Map(s);

            int id;

            using (var srepo = _factory.GetRepo<StudyEntity>())
            {
                id = srepo.Create(sEntity);
            }
            
            return id;
        }

        public void Update(Study s)
        {
            var sEntity = EntityMapper.Map(s);

            using (var srepo = _factory.GetRepo<StudyEntity>())
            {
                srepo.Update(sEntity);
            }
        }


        

    }
}