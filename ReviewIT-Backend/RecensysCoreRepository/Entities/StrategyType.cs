using System.Collections;
using System.Collections.Generic;

namespace RecensysCoreRepository.Entities
{
    public class StrategyType : IEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<Strategy> Strategies { get; set; } = new List<Strategy>();
    }
}
