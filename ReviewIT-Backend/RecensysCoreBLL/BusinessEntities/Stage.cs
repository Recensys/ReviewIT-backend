using TypeLite;

namespace RecensysBLL.BusinessEntities
{
    [TsClass]
    public class Stage
    {
        public int Id { get; set; }

        public StageDetails StageDetails { get; set; }

        public StageFields StageFields { get; set; }

        
    }
}
