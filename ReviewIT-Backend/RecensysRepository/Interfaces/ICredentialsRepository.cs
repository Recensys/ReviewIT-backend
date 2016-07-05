using System;
using System.Collections.Generic;
using RecensysRepository.Entities;

namespace RecensysRepository.Interfaces
{
    public interface ICredentialsRepository : IDisposable
    {
        IEnumerable<CredentialsEntity> GetAll();

        void Create(CredentialsEntity item);

        CredentialsEntity Read(int id);

        void Update(CredentialsEntity item);

        void Delete(int id);
    }
}
