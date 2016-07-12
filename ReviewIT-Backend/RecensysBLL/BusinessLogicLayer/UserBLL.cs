using System;
using System.Collections.Generic;
using System.Linq;
using RecensysBLL.BusinessEntities;
using RecensysRepository.Entities;
using RecensysRepository.Factory;

namespace RecensysBLL.BusinessLogicLayer
{
    public class UserBLL
    {

        private readonly IRepositoryFactory _factory;
        public UserBLL(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        public int CreateUser(User user)
        {
            if (user == null) throw new ArgumentNullException("user null reference");
            if (string.IsNullOrEmpty(user.Username)) throw new ArgumentException("username not valid");
            if (string.IsNullOrEmpty(user.Password)) throw new ArgumentException("password not valid");

            int uid;

            using (var urepo = _factory.GetUserRepo())
            {
                uid = urepo.Create(new UserEntity()
                {
                    Username = user.Username,
                    Password_Salt = user.PasswordSalt,
                    Password = user.Password
                });
            }

            return uid;
        }

        

        public List<User> Get()
        {
            List<UserEntity> entities;

            using (var urepo = _factory.GetUserRepo())
            {
                entities = urepo.GetAll().ToList();
            }

            List<User> users = new List<User>();

            foreach (var entity in entities)
            {
                users.Add(new User() {Username = entity.Username, Password = entity.Password_Salt});
            }

            return users;
        }

        public User Get(string username)
        {
            UserEntity entity;

            using (var urepo = _factory.GetUserRepo())
            {
                entity = urepo.GetAll().Single(e => e.Username.Equals(username));
            }

            return new User()
            {
                Id = entity.Id,
                Username = entity.Username,
                Password = entity.Password,
                PasswordSalt = entity.Password_Salt
            };
        }

        public void AssociateUserToStudy(int userId, int studyId, int roleId)
        {
            using (var repo = _factory.GetUserStudyRelationRepo())
            {
                repo.Create(new User_Stage_RelationEntity()
                {
                    User_Id = userId
                });
            }
        }

        public void UnassociateUserToStudy(int userId, int studyId)
        {
            using (var repo = _factory.GetUserStudyRelationRepo())
            {
                repo.Delete(userId, studyId);
            }
        }

    }
}