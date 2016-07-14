using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;
using RecensysBLL.BusinessEntities;
using RecensysBLL.BusinessEntities.OverviewEntities;
using RecensysRepository.Entities;
using RecensysRepository.Factory;

namespace RecensysBLL.BusinessLogicLayer
{
    public class StudyBLL
    {

        private readonly IRepositoryFactory _factory;

        public StudyBLL(IRepositoryFactory factory)
        {
            _factory = factory;
        }


        public List<StudyOverview> Get(int uid)
        {
            var studies = new List<StudyOverview>();

            using (var studyRepo = _factory.GetStudyRepo())
            {
                
            }
            return null;
        }

        public StudyOverview GetOverview(int id)
        {
            var study = new StudyOverview();
            
            using (var srepo = _factory.GetStudyRepo())
            using (var strepo = _factory.GetStageRepo())
            {

                // Add basic study information
                var studyDto = srepo.Read(id);
                study.Id = studyDto.Id;
                study.Description = studyDto.Description;

                // Add stages
                var stageDtos = strepo.GetAll().Where(dto => dto.Study_Id == id);
                study.Stages = new List<StageOverview>();
                foreach (var dto in stageDtos)
                {
                    study.Stages.Add(new StageOverview()
                    {
                        Id = dto.Id,
                        Name = dto.Name
                    });
                }
                
            }

            return study;

        }

        public void Remove(int id)
        {
            using (var srepo = _factory.GetStudyRepo())
            {
                srepo.Delete(id);
            }
        }
        

        

    }
}