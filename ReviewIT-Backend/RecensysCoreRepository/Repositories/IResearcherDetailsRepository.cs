using System;
using System.Collections.Generic;
using RecensysCoreRepository.DTOs;

namespace RecensysCoreRepository.Repositories
{
    public interface IResearcherDetailsRepository: IDisposable
    {

        IEnumerable<ResearcherDetailsDTO> Get();

    }
}