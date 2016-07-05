namespace RecensysRepository.Entities
{
    public class StrategyEntity
    {
        public int Id { get; set; }
        public int Stage_Id { get; set; }
        public int StrategyType_Id { get; set; }
        public string Value { get; set; }
    }
}