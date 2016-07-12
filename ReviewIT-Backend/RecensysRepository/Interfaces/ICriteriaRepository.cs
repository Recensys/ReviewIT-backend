using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RecensysRepository.Entities;

namespace RecensysRepository.Interfaces
{
    interface ICriteriaRepository : IDisposable
    {
        IEnumerable<CriteriaEntity> GetAll();

        void Create(CriteriaEntity item);

        CriteriaEntity Read(int id);

        void Update(CriteriaEntity item);

        void Delete(int id);
    }
}
