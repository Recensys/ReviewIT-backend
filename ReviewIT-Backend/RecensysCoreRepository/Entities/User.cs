using System.Collections;
using System.Collections.Generic;

namespace RecensysCoreRepository.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password_Salt { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string eMail { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
        public virtual ICollection<UserStageRelation> StageRelations { get; set; } = new List<UserStageRelation>();
        public virtual ICollection<UserStudyRelation> StudyRelations { get; set; } = new List<UserStudyRelation>();
    }
}