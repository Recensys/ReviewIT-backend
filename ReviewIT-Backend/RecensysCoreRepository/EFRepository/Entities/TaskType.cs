using System.Collections;
using System.Collections.Generic;

namespace RecensysCoreRepository.Entities
{
    public class TaskType : IEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
