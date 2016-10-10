using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;

namespace RecensysCoreRepository.Repositories
{
    public interface IStudyConfigRepository : IDisposable
    {
        int Create(StudyConfigDTO dto);
        StudyConfigDTO Read(int id);
        bool Update(StudyConfigDTO dto);
        bool Delete(int id);

    }
}
