using System.Collections.Generic;
using TypeLite;

namespace RecensysBLL.BusinessEntities
{
    [TsClass]
    public class StageFields
    {
        public int Id { get; set; }
        public List<Field> VisibleFields { get; set; }
        public List<Field> RequestedFields { get; set; }
    }
}
