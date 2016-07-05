using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecensysBLL.BusinessEntities
{
    public class ValidationTask
    {
        public Data Data { get; set; }
        public List<ReviewTask> Tasks { get; set; }
    }
}
