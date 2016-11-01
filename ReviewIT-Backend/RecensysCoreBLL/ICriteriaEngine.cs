using System.Threading.Tasks;

namespace RecensysCoreBLL
{
    public interface ICriteriaEngine
    {
        int Evaluate(int stageId);

        Task<int> EvaluateAsync(int stageId);
    }
}