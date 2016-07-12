using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RecensysRepository.Entities;

namespace RecensysRepository.Interfaces
{
    public interface IStageDescriptionRepository : IDisposable
    {
        IEnumerable<StageDescriptionEntity> GetAll();

        int Create(StageDescriptionEntity item);

        StageDescriptionEntity Read(int stageId, int fieldId);

        void Update(StageDescriptionEntity item);

        void Delete(int stageId, int fieldId);
    }
}
