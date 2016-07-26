using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecensysBLL.BusinessEntities
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
