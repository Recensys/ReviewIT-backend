using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.Entities;

namespace RecensysCoreRepository.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll();

        int Create(T item);

        T Read(int id);

        void Update(T item);

        void Delete(int id);
    }
}
