using System;
using System.Collections.Generic;
using RecensysCoreBLL.BusinessEntities;
using RecensysCoreBLL.StrategyHandler;

namespace RecensysCoreBLL.BusinessLogicLayer
{
    public class StrategyBLL
    {
        private static Dictionary<Type, IReviewStrategyHandler> _reviewStrategies = new Dictionary<Type, IReviewStrategyHandler>();


        private readonly IRepositoryFactory _factory;
        public StrategyBLL(IRepositoryFactory factory)
        {
            _factory = factory;
            AddStrategy(new StubReviewStrategyHandler());
        }

        public void AddStrategy(IReviewStrategyHandler strategyHandler)
        {
            _reviewStrategies.Add(strategyHandler.GetType(), strategyHandler);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stageId"></param>
        /// <param name="articles"></param>
        /// <returns>dictionary of article ids per user id</returns>
        public Dictionary<int, List<int>> GetReviewtaskDistribution(int stageId, List<int> articles)
        {
            //TODO use correct handler depending on formatting of data

            string StrategyData;
            using (var strategyRepo = _factory.GetStrategyRepo())
            {
                StrategyData =
                    strategyRepo.GetAll()
                        .Single(e => e.Stage_Id == stageId && e.StrategyType_Id == (int) StrategyType.Review).Value;
            }

            return _reviewStrategies[typeof(StubReviewStrategyHandler)].DivideTasks(articles, StrategyData);
        }

        
    }
}
