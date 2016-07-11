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
    public interface IReviewStrategyHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="articles"></param>
        /// <param name="json"></param>
        /// <returns>a dictionary of article ids per user id</returns>
        Dictionary<int, List<int>> DivideTasks(List<int> articles, string json);
    }
}
