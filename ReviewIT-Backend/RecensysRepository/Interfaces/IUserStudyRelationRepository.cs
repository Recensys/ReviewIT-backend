using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecensysRepository.Entities;

namespace RecensysRepository.Interfaces
{
    public interface IUserStudyRelationRepository : IDisposable
    {
        IEnumerable<User_Study_RelationEntity> GetAll();

        int Create(User_Study_RelationEntity item);

        User_Study_RelationEntity Read(int uid, int sid);

        User_Study_RelationEntity Update(User_Study_RelationEntity item);

        void Delete(int uid, int sid);
    }
}
