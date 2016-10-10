using System.Collections;
using System.Collections.Generic;

namespace RecensysCoreRepository.Entities
{

    public enum StrategyType
    {
        Distribution, Validation
    }

    public class Strategy : IEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public int StageId { get; set; }
        public virtual Stage Stage { get; set; }

        public StrategyType Type { get; set; }

        public virtual ICollection<StrategyFieldRelation> FieldRelations { get; set; } = new List<StrategyFieldRelation>();
    }
}