using System;
using System.Collections.Generic;
using RecensysCoreRepository.Entities;

namespace RecensysCoreRepository.Interfaces
{
    public interface IStageFieldsRepository : IDisposable
    {
        IEnumerable<StageFieldRelation> GetAll();

        int Create(StageFieldRelation item);

        StageFieldRelation Read(int stageId, int fieldId);

        void Update(StageFieldRelation item);

        void Delete(int stageId, int fieldId);
    }
}
