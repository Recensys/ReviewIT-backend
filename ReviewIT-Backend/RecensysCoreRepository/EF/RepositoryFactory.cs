using System;
using Microsoft.EntityFrameworkCore;
using RecensysCoreRepository.Entities;
using RecensysCoreRepository.Repositories;

namespace RecensysCoreRepository.EF
{
    public class RepositoryFactory : IDisposable
    {

        private readonly IRecensysContext _context;


        private StudyDetailsRepository _studyDetailsRepository;
        public StudyDetailsRepository GetStudyDetailsRepository
            => _studyDetailsRepository ?? (_studyDetailsRepository = new StudyDetailsRepository(_context));


        private StudyConfigRepository _studyConfigRepository;
        public StudyConfigRepository GetStudyConfigRepository
            => _studyConfigRepository ?? (_studyConfigRepository = new StudyConfigRepository(_context));



        public RepositoryFactory(IRecensysContext context)
        {
            _context = context;
        }
        

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
