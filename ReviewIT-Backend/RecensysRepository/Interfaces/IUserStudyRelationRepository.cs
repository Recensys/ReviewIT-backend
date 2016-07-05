using System;
using System.Collections.Generic;
using RecensysRepository.Entities;

namespace RecensysRepository.Interfaces
{
    public interface IUserStudyRelationRepository : IDisposable
    {
        IEnumerable<User_Stage_RelationEntity> GetAll();

        void Create(User_Stage_RelationEntity item);

        User_Stage_RelationEntity Read(int uid, int sid);

        void Update(User_Stage_RelationEntity item);

        void Delete(int uid, int sid);
    }
}
