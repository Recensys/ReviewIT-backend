using System.Collections.Generic;

namespace RecensysCoreRepository.DTOs
{
    public class StudyConfigDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<StageConfigDTO> Stages { get; set; }
        public ICollection<FieldDTO> AvailableFields { get; set; }
        public ICollection<ResearcherDetailsDTO> Researchers { get; set; }
        public ICollection<CriteriaDTO> Criteria { get; set; }
    }
}