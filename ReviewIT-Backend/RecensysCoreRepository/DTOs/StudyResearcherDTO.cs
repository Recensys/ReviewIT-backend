using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecensysCoreRepository.DTOs
{
    public enum ResearcherRole
    {
        Researcher, ResearchManager
    }
    public class StudyResearcherDTO
    {
        public int ResearcherId { get; set; }
        public string FirstName { get; set; }
        public ResearcherRole Role { get; set; }
    }
}
