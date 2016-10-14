using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecensysCoreRepository.DTOs
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public ICollection<int> DataIds { get; set; }
        public int OwnerId { get; set; }
    }
}
