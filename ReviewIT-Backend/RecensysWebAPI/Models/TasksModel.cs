using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysBLL.BusinessEntities;
using Task = RecensysBLL.BusinessEntities.Task;

namespace RecensysWebAPI.Models
{
    public class TasksModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Field> Fields { get; set; }
        public List<Task> Tasks { get; set; }

    }
}
