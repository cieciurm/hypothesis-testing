using HypothesisTesting.Domain.Extensions;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Statistics;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;
using static HypothesisTesting.Domain.Constants;

namespace HypothesisTesting.Domain.Strategies
{
    public class PairedIntervalStrategy : IStrategy
    {
        public string SampleType => SamplesTypes.Paired;

        public string ScaleMeasure => ScaleMeasures.Interval;

        private readonly INormalDistributionTest _normalDistributionTest;
        private readonly IStudentPairedTest _studentPairedTest;
        private readonly IWilcoxonSignedRankTest _wilcoxonTest;
        private readonly IExecutionLogger _executionLogger;
        private readonly ITranslator _translator;

        public PairedIntervalStrategy(
            INormalDistributionTest normalDistributionTest,
            IStudentPairedTest studentPairedTest,
            IWilcoxonSignedRankTest wilcoxonTest,
            IExecutionLogger executionLogger,
            ITranslator translator)
        {
            _normalDistributionTest = normalDistributionTest;
            _studentPairedTest = studentPairedTest;
            _wilcoxonTest = wilcoxonTest;
            _executionLogger = executionLogger;
            _translator = translator;
        }

        public OutputData Execute(InputData input)
        {
            var isXNormalDistribution = _normalDistributionTest.IsNormalDistribution(input.XValues, input.Significance);
            var isYNormalDistribution = _normalDistributionTest.IsNormalDistribution(input.YValues, input.Significance);

            double pValue;
            string resultKey;
            if (isXNormalDistribution && isYNormalDistribution)
            {
                pValue = _studentPairedTest.Calculate(input);
                resultKey = Translations.ExpectedValueResult;
            }
            else
            {
                pValue = _wilcoxonTest.Calculate(input);
                resultKey = Translations.SamePopulationResult;
            }

            return OutputData.Success(pValue, resultKey);
        }
    }
}
