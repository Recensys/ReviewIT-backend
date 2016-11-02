using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecensysCoreRepository.DTOs
{
    public class ArticleWithRequestedFieldsDTO
    {
        public ICollection<int> DataIds { get; set; }
        public int ArticleId { get; set; }
    }
}
