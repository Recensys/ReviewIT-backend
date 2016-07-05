using System;
using System.Collections.Generic;
using RecensysRepository.Entities;

namespace RecensysRepository.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<UserEntity> GetAll();

        void Create(UserEntity user);

        UserEntity Read(int id);

        void Update(UserEntity user);

        void Delete(int id);
        
    }
}