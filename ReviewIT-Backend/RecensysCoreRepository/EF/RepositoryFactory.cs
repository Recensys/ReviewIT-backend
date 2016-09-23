using System;
using Microsoft.EntityFrameworkCore;
using RecensysCoreRepository.Entities;
using RecensysCoreRepository.Repositories;

namespace RecensysCoreRepository.EF
{
    public class RepositoryFactory : IDisposable
    {

        private readonly RecensysContext _context;


        private StudyDetailsRepository _studyDetailsRepository;
        public StudyDetailsRepository GetStudyDetailsRepository
            => _studyDetailsRepository ?? (_studyDetailsRepository = new StudyDetailsRepository(_context));

        
        

        public RepositoryFactory(RecensysContext context)
        {
            _context = context;
        }
        

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
