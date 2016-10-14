using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecensysCoreBLL
{
    interface ITaskEngine
    {
        int Generate(int stageId);
        Task<int> GenerateAsync(int stageId);
    }
}
