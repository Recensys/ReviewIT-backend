using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecensysRepository.Entities
{
    class CriteriaEntity
    {
        public int Id { get; set; }
        public int Study_Id { get; set; }
        public int Field_Id { get; set; }
        public string Value { get; set; }
    }
}
