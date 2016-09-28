using System.Collections;
using System.Collections.Generic;

namespace RecensysCoreRepository.Entities
{
    public class Field : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int DataType { get; set; }

        public int StudyId { get; set; }
        public virtual Study Study { get; set; }

        public virtual ICollection<StrategyFieldRelation> StrategyRelations { get; set; } = new List<StrategyFieldRelation>();
        public virtual ICollection<Criteria> Criteria { get; set; } = new List<Criteria>();
        public virtual ICollection<Data> Data { get; set; } = new List<Data>();
        public virtual ICollection<StageFieldRelation> StageFields { get; set; } = new List<StageFieldRelation>();
    }
}