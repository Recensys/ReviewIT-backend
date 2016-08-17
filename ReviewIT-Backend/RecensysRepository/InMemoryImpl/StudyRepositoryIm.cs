using System.Collections.Generic;
using System.Linq;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    public class StudyRepositoryIm : IStudyRepository
    {

        private readonly List<StudyEntity> _studies = new List<StudyEntity>()
        {
        };

        public void Dispose()
        {
        }

        public IEnumerable<StudyEntity> GetAll()
        {
            return _studies;
        }

        public int Create(StudyEntity study)
        {
            _studies.Add(study);
            study.Id = _studies.Max(s => s.Id) + 1;
            return study.Id;
        }

        public StudyEntity Read(int id)
        {
            return _studies.Find(dto => dto.Id == id);
        }

        public void Update(StudyEntity study)
        {
            _studies.RemoveAll(dto => dto.Id == study.Id);
            _studies.Add(study);
        }

        public void Delete(int id)
        {
            _studies.RemoveAll(dto => dto.Id == id);
        }
    }
}