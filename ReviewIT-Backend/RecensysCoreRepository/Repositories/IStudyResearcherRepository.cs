using System;
using System.Collections.Generic;
using RecensysCoreRepository.DTOs;

namespace RecensysCoreRepository.Repositories
{
    public interface IStudyResearcherRepository: IDisposable
    {
        ICollection<StudyResearcherDTO> Get(int studyId);
        bool Create(int studyId, StudyResearcherDTO dto);
        bool Update(int studyId, StudyResearcherDTO[] dtos);
        bool Delete(int studyId, StudyResearcherDTO dto);
    }
}