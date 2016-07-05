using System;
using System.Collections.Generic;
using RecensysRepository.Entities;

namespace RecensysRepository.Interfaces
{
    public interface IStudyRoleRepository : IDisposable
    {
        IEnumerable<User_Study_RelationEntity> GetAll();

        void Create(User_Study_RelationEntity item);

        User_Study_RelationEntity Read(int id);

        void Update(User_Study_RelationEntity item);

        void Delete(int id);
    }
}
