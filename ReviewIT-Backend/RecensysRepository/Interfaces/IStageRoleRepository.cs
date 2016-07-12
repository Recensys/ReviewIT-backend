using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RecensysRepository.Entities;

namespace RecensysRepository.Interfaces
{
    interface IStageRoleRepository : IDisposable
    {
        IEnumerable<StageRoleEntity> GetAll();

        void Create(StageRoleEntity item);

        StageRoleEntity Read(int id);

        void Update(StageRoleEntity item);

        void Delete(int id);
    }
}
