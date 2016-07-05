using System;
using System.Collections.Generic;
using RecensysRepository.Entities;

namespace RecensysRepository.Interfaces
{
    public interface IStudyRepository : IDisposable
    {
        IEnumerable<StudyEntity> GetAll();

        void Create(StudyEntity study);

        StudyEntity Read(int id);

        void Update(StudyEntity study);

        void Delete(int id);
    }
}