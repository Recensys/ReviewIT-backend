using System.Collections;
using System.Collections.Generic;

namespace RecensysCoreRepository.Entities
{
    public class Strategy : IEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public int StageId { get; set; }
        public virtual Stage Stage { get; set; }

        public int StrategyTypeId { get; set; }
        public virtual StrategyType StrategyType { get; set; }

        public virtual ICollection<StrategyFieldRelation> FieldRelations { get; set; } = new List<StrategyFieldRelation>();
    }
}