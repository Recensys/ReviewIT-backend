using System.Collections.Generic;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    public class UserStudyRelationRepositoryIm : IUserStudyRelationRepository
    {

        private List<User_Stage_RelationEntity> _relations = new List<User_Stage_RelationEntity>() {
            new User_Stage_RelationEntity() { StudyRole_Id = 1, Study_Id = 1, Id = 1},
            new User_Stage_RelationEntity() { StudyRole_Id = 1, Study_Id = 1, Id = 2},
        };

        public void Create(User_Stage_RelationEntity item)
        {
            _relations.Add(item);
        }

        public void Delete(int uid, int sid)
        {
            _relations.RemoveAll(dto => dto.Id == uid && dto.Study_Id == sid);
        }

        public void Dispose()
        {
        }

        public IEnumerable<User_Stage_RelationEntity> GetAll()
        {
            return _relations;
        }

        public User_Stage_RelationEntity Read(int uid, int sid)
        {
            return _relations.Find(dto => dto.Id == uid && dto.Study_Id == sid);
        }

        public void Update(User_Stage_RelationEntity item)
        {
            _relations.RemoveAll(dto => dto.Id == item.Id && dto.Study_Id == item.Study_Id);
            _relations.Add(item);
        }
    }
}