using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RecensysCoreRepository.DTOs
{
    public class StageConfigDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<FieldDTO> VisibleFields { get; set; }
        public List<FieldDTO> RequestedFields { get; set; }

    }
}
