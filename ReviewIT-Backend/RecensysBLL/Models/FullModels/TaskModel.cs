using System.Collections.Generic;

namespace RecensysBLL.Models.FullModels
{

    public enum TaskType
    {
        Review, Validation
    }

    public class TaskModel
    {
        public int Id { get; set; }
        public List<DataModel> Data { get; set; }
    }
}