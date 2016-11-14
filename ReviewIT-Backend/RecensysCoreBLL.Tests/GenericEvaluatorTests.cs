using RecensysCoreBLL.CriteriaEngine.Evaluators;
using Xunit;

namespace RecensysCoreBLL.Tests
{
    public class GenericEvaluatorTests
    {
        [Fact]
        public void Evaluate_2largerThan1_true()
        {
            var g = new GenericEvaluator();

            var r = g.Eval("2", ">", "1");

            Assert.True(r);
        }

        [Fact]
        public void Evaluate_2largerThan3_false()
        {
            var g = new GenericEvaluator();

            var r = g.Eval("2", ">", "3");

            Assert.False(r);
        }

        [Fact]
        public void Evaluate_trueEqualsTrue_true()
        {
            var g = new GenericEvaluator();

            var r = g.Eval("true", "==", "true");

            Assert.True(r);
        }

        [Fact]
        public void Evaluate_trueUnequalsTrue_false()
        {
            var g = new GenericEvaluator();

            var r = g.Eval("true", "!=", "true");

            Assert.False(r);
        }
    }
}