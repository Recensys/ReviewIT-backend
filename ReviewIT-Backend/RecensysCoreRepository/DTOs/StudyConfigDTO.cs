using System.Collections.Generic;

namespace RecensysCoreRepository.DTOs
{
    public class StudyConfigDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<StageConfigDTO> Stages { get; set; }
        public List<FieldDTO> AvailableFields { get; set; }
        public List<ResearcherDetailsDTO> Researchers { get; set; }
        public List<CriteriaDTO> Criteria { get; set; }
    }
}