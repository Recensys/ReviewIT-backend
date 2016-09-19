using System;
using RecensysCoreRepository.Entities;

namespace RecensysCoreRepository.EF
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IDbContext _context;

        public RepositoryFactory(IDbContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepo<T>() where T : class, IEntity
        {
            return new Repository<T>(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
