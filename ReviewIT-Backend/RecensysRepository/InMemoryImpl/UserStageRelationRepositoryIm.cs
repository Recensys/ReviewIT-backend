using System.Collections.Generic;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    public class UserStageRelationRepositoryIm : IUserStageRelationRepository
    {

        private List<User_Stage_RelationEntity> _relations = new List<User_Stage_RelationEntity>() {
        };

        public void Create(User_Stage_RelationEntity item)
        {
            _relations.Add(item);
        }

        public void Delete(int uid, int sid)
        {
            _relations.RemoveAll(dto => dto.User_Id == uid && dto.Stage_Id == sid);
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
            return _relations.Find(dto => dto.Stage_Id == uid && dto.Stage_Id == sid);
        }

        public void Update(User_Stage_RelationEntity item)
        {
            _relations.RemoveAll(dto => dto.Stage_Id == item.Stage_Id);
            _relations.Add(item);
        }
    }
}