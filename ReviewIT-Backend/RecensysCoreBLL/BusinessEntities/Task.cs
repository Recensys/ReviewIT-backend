using System.Collections.Generic;

namespace RecensysCoreBLL.BusinessEntities
{
    public enum TaskType
    {
        Review, Validation
    }

    public enum TaskState
    {
        New, InProgress, Done
    }

    public class Task
    {
        public int Id { get; set; }
        public List<Data> Data { get; set; }
        public TaskState TaskState { get; set; }
    }
}
