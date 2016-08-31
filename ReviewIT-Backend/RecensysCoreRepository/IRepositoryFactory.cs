using System;
using RecensysCoreRepository.Entities;

namespace RecensysCoreRepository
{
    interface IRepositoryFactory : IDisposable
    {
        IRepository<T> GetRepo<T>() where T : class, IEntity;
    }
}
