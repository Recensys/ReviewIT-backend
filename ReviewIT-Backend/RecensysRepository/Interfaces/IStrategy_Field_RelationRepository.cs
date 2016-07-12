using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RecensysRepository.Entities;

namespace RecensysRepository.Interfaces
{
    public interface IStrategy_Field_RelationRepository : IDisposable
    {
        IEnumerable<Strategy_Field_RelationEntity> GetAll();

        int Create(Strategy_Field_RelationEntity item);

        Strategy_Field_RelationEntity Read(int id);

        void Update(Strategy_Field_RelationEntity item);

        void Delete(int id);
    }
}
