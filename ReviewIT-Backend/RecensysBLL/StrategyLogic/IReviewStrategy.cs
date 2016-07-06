using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecensysBLL.BusinessEntities;
using RecensysBLL.BusinessLogicLayer;

namespace RecensysBLL.StrategyLogic
{
    public interface IReviewStrategy
    {
        string Name { get; set; }

        void GenerateTasks(List<Article> articles, string json);
    }
}
