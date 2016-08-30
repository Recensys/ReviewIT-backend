using System;
using System.Collections.Generic;
using RecensysCoreRepository.Entities;

namespace RecensysCoreRepository.Interfaces
{
    public interface IUserStudyRelationRepository
    {
        IEnumerable<UserStudyRelation> GetAll();

        int Create(UserStudyRelation item);

        UserStudyRelation Read(int uid, int sid);

        UserStudyRelation Update(UserStudyRelation item);

        void Delete(int uid, int sid);
    }
}
