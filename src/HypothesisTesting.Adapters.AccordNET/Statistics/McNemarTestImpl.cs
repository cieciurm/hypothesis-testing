using Accord.Statistics.Analysis;
using Accord.Statistics.Testing;
using HypothesisTesting.Domain.Ports.Statistics;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;

namespace HypothesisTesting.Adapters.AccordNET.Statistics
{
    internal class McNemarTestImpl : IMcNemarTest
    {
        private readonly IExecutionLogger _executionLogger;
        private readonly ITranslator _translator;

        public McNemarTestImpl(
            IExecutionLogger executionLogger,
            ITranslator translator)
        {
            _executionLogger = executionLogger;
            _translator = translator;
        }

        public double Calculate(int[,] contingencyMatrix, double significance)
        {
            var confusionMatrix = new ConfusionMatrix(contingencyMatrix);
            var fisher = new McNemarTest(confusionMatrix)
            {
                Size = significance
            };

            return fisher.PValue;
        }
    }
}