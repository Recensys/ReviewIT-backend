using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysBLL.BusinessEntities;

namespace RecensysWebAPI.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public List<Field> Fields { get; set; }
    }
}
