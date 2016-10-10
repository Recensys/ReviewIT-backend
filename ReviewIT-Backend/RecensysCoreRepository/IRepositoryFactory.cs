using System;
using RecensysCoreRepository.EFRepository.Entities;
using RecensysCoreRepository.Repositories;

namespace RecensysCoreRepository
{
    public interface IRepositoryFactory : IDisposable
    {
        IStudyConfigRepository GetStudyConfigRepository { get; }
        IStudyDetailsRepository GetStudyDetailsRepository { get; }

        IStudySourceRepository GetStudySourceRepository { get; }

        IRepository<T> GetRepo<T>() where T : class, IEntity;
    }
}
