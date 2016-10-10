namespace RecensysCoreRepository.Entities
{
    public class StrategyFieldRelation
    {
        public int StrategyId { get; set; }
        public virtual Strategy Strategy { get; set; }

        public int FieldId { get; set; }
        public virtual Field Field { get; set; }
    }
}
