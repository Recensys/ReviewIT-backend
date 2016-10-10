using System.Collections;
using System.Collections.Generic;

namespace RecensysCoreRepository.Entities
{
    public class StageRole : IEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<UserStageRelation> UserStageRelations { get; set; } = new List<UserStageRelation>();
    }
}
