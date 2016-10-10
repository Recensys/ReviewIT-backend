using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;

namespace RecensysCoreRepository.Repositories
{
    public interface IStudyDetailsRepository: IDisposable
    {
        IEnumerable<StudyDetailsDTO> GetAll();


    }
}
