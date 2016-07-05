using System.Collections.Generic;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    public class StudyRoleRepositoryIm : IStudyRoleRepository
    {

        private List<User_Study_RelationEntity> _roles = new List<User_Study_RelationEntity>()
        {
            new User_Study_RelationEntity() {Id = 1, Name = "Admin" },
            new User_Study_RelationEntity() {Id = 2, Name = "Researcher" },
            new User_Study_RelationEntity() {Id = 3, Name = "Guest" },
        };

        public void Create(User_Study_RelationEntity item)
        {
            _roles.Add(item);
        }

        public void Delete(int id)
        {
            _roles.RemoveAll(dto => dto.Id == id);
        }

        public void Dispose()
        {
        }

        public IEnumerable<User_Study_RelationEntity> GetAll()
        {
            return _roles;
        }

        public User_Study_RelationEntity Read(int id)
        {
            return _roles.Find(dto => dto.Id == id);
        }

        public void Update(User_Study_RelationEntity item)
        {
            _roles.RemoveAll(dto => dto.Id == item.Id);
            _roles.Add(item);
        }
    }
}