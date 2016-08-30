namespace RecensysCoreRepository.Entities
{
    public class Criteria
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public int StudyId { get; set; }
        public virtual Study Study { get; set; }

        public int FieldId { get; set; }
        public virtual Field Field { get; set; }
    }
}
