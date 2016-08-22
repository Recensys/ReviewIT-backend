using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysBLL.BusinessEntities;

namespace RecensysWebAPI.Models
{
    public class StageDescriptionModel
    {
        public List<Field> Visible { get; set; }
        public List<Field> Requested { get; set; }
    }
}
