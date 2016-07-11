using System.Collections.Generic;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    public class StudyRoleRepository : IStudyRoleRepository
    {

        private List<User_Study_RelationEntity> _roles = new List<User_Study_RelationEntity>()
        {
        };
        public void Create(User_Study_RelationEntity item)
        {
            _roles.Add(item);
        }

        public void Delete(int id)
        {
            _roles.RemoveAll(dto => dto.Study_Id == id);
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
            return _roles.Find(dto => dto.Study_Id == id);
        }

        public void Update(User_Study_RelationEntity item)
        {
            _roles.RemoveAll(dto => dto.Study_Id == item.Study_Id);
            _roles.Add(item);
        }
    }
}