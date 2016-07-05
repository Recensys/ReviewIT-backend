using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecensysBLL.BusinessLogicLayer;

namespace RecensysBLL.StrategyLogic
{
    class TestStrategy : IStrategy
    {
        public string Name { get; set; }
        public void GenerateTasks(Action<int?, int, int, int[]> generateTask)
        {
            generateTask(0,0,0,new []{0});
        }
    }
}
