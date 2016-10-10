using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EFRepository.Entities;
using RecensysCoreRepository.Repositories;

namespace RecensysCoreRepository.EFRepository.Repositories
{
    public class StudyResearcherRepository : IStudyResearcherRepository
    {

        private IRecensysContext _context;

        public StudyResearcherRepository(IRecensysContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public ICollection<StudyResearcherDTO> Get(int studyId)
        {
            return (from s in _context.UserStudyRelations
                where s.StudyId == studyId
                select new StudyResearcherDTO
                {
                    ResearcherId = s.UserId,
                    FirstName = s.User.FirstName,
                    Role = s.IsAdmin ? ResearcherRole.ResearchManager : ResearcherRole.Researcher
                }).ToList();
        }

        public bool Create(int studyId, StudyResearcherDTO dto)
        {
            _context.UserStudyRelations.Add(new UserStudyRelation()
            {
                IsAdmin = dto.Role == ResearcherRole.ResearchManager,
                StudyId = studyId,
                UserId = dto.ResearcherId
            });
            return _context.SaveChanges() > 0;
        }

        public bool Update(int studyId, StudyResearcherDTO[] dtos)
        {
            var stored = (from s in _context.UserStudyRelations
                where s.StudyId == studyId
                select s).ToList();

            // remove entries in store that are not passed in dto
            foreach (var re in stored)
                if (dtos.All(d => d.ResearcherId == re.UserId)) _context.UserStudyRelations.Remove(re);

            // map data
            foreach (var dto in dtos)
            {
                var r = _context.UserStudyRelations.SingleOrDefault(us => us.UserId == dto.ResearcherId);
                if (r == null)
                {
                    r = new UserStudyRelation()
                    {
                        IsAdmin = dto.Role == ResearcherRole.ResearchManager,
                        UserId = dto.ResearcherId,
                        StudyId = studyId
                    };
                    _context.UserStudyRelations.Add(r);
                }
                else
                {
                    r.IsAdmin = dto.Role == ResearcherRole.ResearchManager;
                }

            }
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int studyId, StudyResearcherDTO dto)
        {
            var entity = _context.UserStudyRelations.Single(us => us.StudyId == studyId && us.UserId == dto.ResearcherId);
            _context.UserStudyRelations.Remove(entity);
            return _context.SaveChanges() > 0;
        }
    }
}
