using System;
using RecensysCoreRepository.Entities;

namespace RecensysCoreRepository
{
    public interface IRepositoryFactory : IDisposable
    {
        IRepository<T> GetRepo<T>() where T : class, IEntity;
    }
}
