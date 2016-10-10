using System.Collections.Generic;

namespace RecensysCoreRepository.EFRepository.Entities
{
    public class TaskType : IEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
