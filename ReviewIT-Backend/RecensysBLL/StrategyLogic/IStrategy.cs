using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecensysBLL.BusinessLogicLayer;

namespace RecensysBLL.StrategyLogic
{
    public interface IStrategy
    {
        string Name { get; set; }

        void GenerateTasks(Action<int?, int, int, int[]> generateTask);
    }
}
