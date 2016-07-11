using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecensysBLL.BusinessEntities;
using RecensysBLL.BusinessLogicLayer;
using Task = RecensysBLL.BusinessEntities.Task;

namespace RecensysBLL.StrategyLogic
{
    class StubReviewStrategyHandler : IReviewStrategyHandler
    {
        
        
        public Dictionary<int, List<int>> DivideTasks(List<int> articles, string json)
        {
            return new Dictionary<int, List<int>>
            {
                {1, new List<int>() {1, 2, 3, 4, 5}},
                {2, new List<int>() {6, 7, 8, 9, 10}}
            };
        }

    }
}
