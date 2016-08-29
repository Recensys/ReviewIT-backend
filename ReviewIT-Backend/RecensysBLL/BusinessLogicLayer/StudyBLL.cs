using System;
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


        public List<StudyOverview> Get()
        {
            var studies = new List<StudyOverview>();

            using (var studyRepo = _factory.GetStudyRepo())
            {
                var studyEntities = studyRepo.GetAll();
                //TODO check user relation to studies
                foreach (var studyEntity in studyEntities)
                {
                    studies.Add(new StudyOverview()
                    {
                        Id = studyEntity.Id,
                        Name = studyEntity.Title,
                        Description = studyEntity.Description
                    });
                }
            }

            return studies;
        }

        public Study Get(int id)
        {
            var study = new Study() {Id = id};

            // get study details
            using (var studyRepo = _factory.GetStudyRepo())
            {
                var studyEntity = studyRepo.Read(id);
                if (studyEntity == null) throw new NullReferenceException("Study not found");
                study.StudyDetails = new StudyDetails()
                {
                    Name = studyEntity.Title,
                    Description = studyEntity.Description
                };
            }

            // get stages
            study.Stages = new StageBLL(_factory).GetStagesForStudy(id);

            // get researchers
            study.Researchers = new UserBLL(_factory).GetUsersForStudy(id);

            // get available fields
            study.AvailableFields = new FieldBLL(_factory).GetFieldsForStudy(id);

            
            
            return study;
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

        public void UpdateStudy(Study study)
        {
            using (var srepo = _factory.GetStudyRepo())
            {
                srepo.Update(new StudyEntity()
                {
                    Id = study.Id,
                    Description = study.StudyDetails.Description,
                    Title = study.StudyDetails.Name
                });
            }

            foreach (var stage in study.Stages)
            {
                if (stage.Id == -1)
                {
                    new StageBLL(_factory).AddStage(stage, study.Id);
                }
                else
                {
                    new StageBLL(_factory).SaveStage(stage);
                }
            }

            
        }

        public int NewStudy()
        {
            using (var srepo = _factory.GetStudyRepo())
            {
                return srepo.Create(new StudyEntity());
            }
        }

        public void Remove(int id)
        {
            using (var srepo = _factory.GetStudyRepo())
            {
                srepo.Delete(id);
            }
        }

        public int StartStudy(int id)
        {
            int firstStageId;
            using (var studyRepo = _factory.GetStudyRepo())
            {
                firstStageId = studyRepo.Read(id).First_Stage_Id;
            }
           
            int NrOfCreatedTasks = new TaskBLL(_factory).GenerateTasks(firstStageId);
            return NrOfCreatedTasks;
        }
        

    }
}