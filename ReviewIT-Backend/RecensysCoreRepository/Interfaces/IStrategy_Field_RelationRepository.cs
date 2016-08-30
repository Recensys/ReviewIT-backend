using System;
using System.Collections.Generic;
using RecensysCoreRepository.Entities;

namespace RecensysCoreRepository.Interfaces
{
    public interface IStrategyFieldRelationRepository : IDisposable
    {
        IEnumerable<StrategyFieldRelation> GetAll();

        int Create(StrategyFieldRelation item);

        StrategyFieldRelation Read(int id);

        void Update(StrategyFieldRelation item);

        void Delete(int id);
    }
}
