using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecensysCoreRepository.DTOs
{
    public class DistributionDTO
    {
        public int StageId { get; set; }
        public bool? IsRandomized { get; set; }
        public Dictionary<ResearcherDetailsDTO, double> Distribution { get; set; }

    }
}
