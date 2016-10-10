using System.Collections.Generic;

namespace RecensysCoreBLL.BusinessEntities
{
    public class StageFields
    {
        public int Id { get; set; }
        public List<Field> VisibleFields { get; set; }
        public List<Field> RequestedFields { get; set; }
    }
}
