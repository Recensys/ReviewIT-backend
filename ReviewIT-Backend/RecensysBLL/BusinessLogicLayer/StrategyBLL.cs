using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecensysBLL.Exceptions;
using RecensysBLL.StrategyLogic;

namespace RecensysBLL.BusinessLogicLayer
{
    public class StrategyBLL
    {
        private static Dictionary<string, IReviewStrategy> _reviewStrategies = new Dictionary<string, IReviewStrategy>();

        public void AddStrategy(IReviewStrategy strategy)
        {
            _reviewStrategies.Add(strategy.Name, strategy);
        }

        public IReviewStrategy FindStrategy(string name)
        {
            IReviewStrategy strategy;
            try
            {
                strategy = _reviewStrategies[name];
            }
            catch (KeyNotFoundException)
            {
                throw new StrategyNotFoundException($"Strategy with name {name} was not found");
            }

            return strategy;
        }

        
    }
}
