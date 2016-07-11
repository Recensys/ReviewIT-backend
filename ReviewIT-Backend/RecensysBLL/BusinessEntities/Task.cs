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

    public class Task
    {
        public int Id { get; set; }
        public Dictionary<string,string> DataDictionary { get; set; }
        public bool Done { get; set; }
    }
}
