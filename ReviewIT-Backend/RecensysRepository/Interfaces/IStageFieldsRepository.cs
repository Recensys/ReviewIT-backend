using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RecensysRepository.Entities;

namespace RecensysRepository.Interfaces
{
    public interface IStageFieldsRepository : IDisposable
    {
        IEnumerable<StageFieldEntity> GetAll();

        int Create(StageFieldEntity item);

        StageFieldEntity Read(int stageId, int fieldId);

        void Update(StageFieldEntity item);

        void Delete(int stageId, int fieldId);
    }
}
