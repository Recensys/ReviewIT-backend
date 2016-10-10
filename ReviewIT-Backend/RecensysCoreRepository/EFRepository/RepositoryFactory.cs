using System;
using Microsoft.EntityFrameworkCore;
using RecensysCoreRepository.Entities;
using RecensysCoreRepository.Repositories;

namespace RecensysCoreRepository.EF
{
    public class RepositoryFactory : IRepositoryFactory
    {

        private readonly IRecensysContext _context;


        private IStudyDetailsRepository _studyDetailsRepository;
        public IStudyDetailsRepository GetStudyDetailsRepository
            => _studyDetailsRepository ?? (_studyDetailsRepository = new StudyDetailsRepository(_context));

        private IStudySourceRepository _studySourceRepository;
        public IStudySourceRepository GetStudySourceRepository
            => _studySourceRepository ?? (_studySourceRepository = new StudySourceRepository(_context));


        private IStudyConfigRepository _studyConfigRepository;
        public IStudyConfigRepository GetStudyConfigRepository
            => _studyConfigRepository ?? (_studyConfigRepository = new StudyConfigRepository(_context));



        public RepositoryFactory(IRecensysContext context)
        {
            _context = context;
        }
        

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<T> GetRepo<T>() where T : class, IEntity
        {
            throw new NotImplementedException();
        }
    }
}
