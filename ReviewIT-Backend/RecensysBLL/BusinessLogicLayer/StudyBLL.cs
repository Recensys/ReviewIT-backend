using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;
using RecensysBLL.Models;
using RecensysBLL.Models.FullModels;
using RecensysBLL.Models.OverviewModels;
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

        public void AddNew(StudyOverviewModel studyOverview)
        {
            using (var srepo = _factory.GetStudyRepo())
            {
                srepo.Create(new StudyEntity()
                {
                    Id = studyOverview.Id,
                    Name = studyOverview.Name,
                    Description = studyOverview.Description,
                });
            }
        }

        public List<StudyOverviewModel> Get()
        {
            using (var srepo = _factory.GetStudyRepo())
            {
                var dtos = srepo.GetAll();
                var res = new List<StudyOverviewModel>();
                foreach (var dto in dtos)
                {
                    res.Add(new StudyOverviewModel()
                    {
                        Id = dto.Id,
                        Name = dto.Name,
                        Description = dto.Description
                    });
                }
                return res;
            }
        }

        public StudyModel Get(int id)
        {
            using (var srepo = _factory.GetStudyRepo())
            using (var strepo = _factory.GetStageRepo())
            using (var usrepo = _factory.GetUserStudyRelationRepo())
            using (var urepo = _factory.GetUserRepo())
            using (var rrepo = _factory.GetStudyRoleRepo())
            {
                var study = new StudyModel();

                // Add basic study information
                var studyDto = srepo.Read(id);
                study.Id = studyDto.Id;
                study.Name = studyDto.Name;
                study.Description = studyDto.Description;

                // Add stages
                var stageDtos = strepo.GetAll().Where(dto => dto.Study_Id == id);
                study.Stages = new List<StageOverviewModel>();
                foreach (var dto in stageDtos)
                {
                    study.Stages.Add(new StageOverviewModel()
                    {
                        Id = dto.Id,
                        Name = dto.Name
                    });
                }

                // Add persons
                var relationDtos = usrepo.GetAll().Where(us => us.Study_Id == id);
                var userStudyRoleDictionary = new Dictionary<int, List<StudyRole>>();
                foreach (var dto in relationDtos)
                {
                    if (userStudyRoleDictionary.ContainsKey(dto.Id))
                    {
                        userStudyRoleDictionary[id].Add(new StudyRole()
                        {
                            Id = dto.StudyRole_Id,
                            Name = rrepo.Read(dto.StudyRole_Id).Name
                        });
                    }
                    else
                    {
                        userStudyRoleDictionary.Add(dto.Id, new List<StudyRole>() { new StudyRole(){
                            Id = dto.StudyRole_Id,
                            Name = rrepo.Read(dto.StudyRole_Id).Name
                        }});
                    }
                }
                study.Persons = new Dictionary<UserModel, List<StudyRole>>();
                foreach (var userPair in userStudyRoleDictionary)
                {
                    // TODO build dictionary in one iteration
                    var userDto = urepo.Read(userPair.Key);
                    study.Persons.Add(new UserModel()
                    {
                        Id = userDto.Id,
                        FirstName = userDto.FirstName,
                        LastName = userDto.LastName,
                        Metadata = userDto.Metadata
                    }, userPair.Value);
                }

                return study;
            }
            
        }

        public void Remove(int id)
        {
            using (var srepo = _factory.GetStudyRepo())
            {
                srepo.Delete(id);
            }
        }


        public void AddStage(StageModel stage)
        {
            using (var repo = _factory.GetStageRepo())
            using (var srepo = _factory.GetStrategyRepo())
            {
                /*
                srepo.Update(new StrategyDTO()
                {
                    Study_Id = stage.Strategy.Id,
                    Name = stage.Strategy.Name
                });*/

                repo.Create(new StageEntity()
                {
                    Name = stage.Name,
                    Description = stage.Description
                });
            }
        }

        public void RemoveStage(int id)
        {
            using (var repo = _factory.GetStageRepo())
            {
                repo.Delete(id);
            }
        }

    }
}