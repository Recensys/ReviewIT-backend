using System.Collections;
using System.Collections.Generic;

namespace RecensysCoreRepository.Entities
{
    public class DataType
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<Field> Fields { get; set; } = new List<Field>();
    }
}
