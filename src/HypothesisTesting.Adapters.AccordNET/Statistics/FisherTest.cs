using Accord.Statistics.Analysis;
using Accord.Statistics.Testing;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Statistics;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;

namespace HypothesisTesting.Adapters.AccordNET.Statistics
{


    internal class FisherTest : IFisherTest
    {
        private readonly IContingencyMatrixCalculator _contingencyMatrixCalculator;
        private readonly IExecutionLogger _executionLogger;
        private readonly ITranslator _translator;

        public FisherTest(IContingencyMatrixCalculator contingencyMatrixCalculator, IExecutionLogger executionLogger, ITranslator translator)
        {
            _contingencyMatrixCalculator = contingencyMatrixCalculator;
            _executionLogger = executionLogger;
            _translator = translator;
        }

        public double Calculate(InputData inputData)
        {
            var matrix = _contingencyMatrixCalculator.Calculate(inputData);

            var confusionMatrix = new ConfusionMatrix(matrix);
            var fisher = new FisherExactTest(confusionMatrix)
            {
                Size = inputData.Significance
            };

            return fisher.PValue;
        }
    }

    internal class McNemarTestImpl : IMcNemarTest
    {
        private readonly IContingencyMatrixCalculator _contingencyMatrixCalculator;
        private readonly IExecutionLogger _executionLogger;
        private readonly ITranslator _translator;

        public McNemarTestImpl(IContingencyMatrixCalculator contingencyMatrixCalculator, IExecutionLogger executionLogger, ITranslator translator)
        {
            _contingencyMatrixCalculator = contingencyMatrixCalculator;
            _executionLogger = executionLogger;
            _translator = translator;
        }

        public double Calculate(InputData inputData)
        {
            var matrix = _contingencyMatrixCalculator.Calculate(inputData);

            var confusionMatrix = new ConfusionMatrix(matrix);
            var fisher = new McNemarTest(confusionMatrix)
            {
                Size = inputData.Significance
            };

            return fisher.PValue;
        }
    }
}
