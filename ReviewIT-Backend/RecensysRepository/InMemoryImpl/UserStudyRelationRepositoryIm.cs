using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    class UserStudyRelationRepositoryIm : IUserStudyRelationRepository
    {

        private List<User_Study_RelationEntity> _relations = new List<User_Study_RelationEntity>();
        

        public void Dispose()
        {
        }

        public IEnumerable<User_Study_RelationEntity> GetAll()
        {
            return _relations;
        }

        public int Create(User_Study_RelationEntity item)
        {
            _relations.Add(item);
            return -1;
        }

        public User_Study_RelationEntity Read(int uid, int sid)
        {
            return _relations.Find(r => r.Study_Id == sid && r.User_Id == uid);
        }

        public User_Study_RelationEntity Update(User_Study_RelationEntity item)
        {
            _relations.RemoveAll(dto => dto.Study_Id == item.Study_Id);
            _relations.Add(item);
            return item;
        }

        public void Delete(int uid, int sid)
        {
            _relations.RemoveAll(dto => dto.Study_Id == sid && dto.User_Id == uid);
        }
    }
}
