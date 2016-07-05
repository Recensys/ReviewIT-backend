using System.Collections.Generic;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    public class UserRepositoryIm : IUserRepository
    {

        private List<UserEntity> _users = new List<UserEntity>()
        {
            new UserEntity() {Id = 1, LastName = "Pedersen", FirstName = "Mathias"},
            new UserEntity() {Id = 2, LastName = "Cholewa", FirstName = "Jacob"}
        };
        private List<User_Study_RelationEntity> _roles = new List<User_Study_RelationEntity>()
        {
            new User_Study_RelationEntity() {Id = 1, Name = "Admin" }
        };
        private List<User_Stage_RelationEntity> _userStudyRelation = new List<User_Stage_RelationEntity>()
        {
            new User_Stage_RelationEntity() {Id = 1, Study_Id = 1, StudyRole_Id = 1 }
        };

        public void Dispose()
        {
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return _users;
        }

        public void Create(UserEntity user)
        {
            _users.Add(user);
        }

        public UserEntity Read(int id)
        {
            return _users.Find(dto => dto.Id == id);
        }

        public void Update(UserEntity user)
        {
            _users.RemoveAll(dto => dto.Id == user.Id);
            _users.Add(user);
        }

        public void Delete(int id)
        {
            _users.RemoveAll(dto => dto.Id == id);
        }
        
    }
}