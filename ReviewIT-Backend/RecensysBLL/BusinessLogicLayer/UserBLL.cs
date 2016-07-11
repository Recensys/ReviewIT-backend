using System;
using RecensysBLL.Models;
using RecensysBLL.Models.FullModels;
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

        public void Add(UserModel model)
        {
            if (model == null) throw new ArgumentNullException("Model null reference");
            if (model.Id < 0) throw new ArgumentException("id under 0");

            using (var urepo = _factory.GetUserRepo())
            {
                urepo.Create(new UserEntity()
                {
                    Id = model.Id,
                    First_Name = model.FirstName,
                    Last_Name = model.LastName
                });
            }
        }

        public UserModel Get(int id)
        {
            using (var urepo = _factory.GetUserRepo())
            {
                var dto = urepo.Read(id);
                if (dto == null) throw new IndexOutOfRangeException();

                return new UserModel()
                {
                    Id = dto.Id,
                    FirstName = dto.First_Name,
                    LastName = dto.Last_Name
                };
            }
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