using HypothesisTesting.Domain.Extensions;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Statistics;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;

namespace HypothesisTesting.Domain.Strategies
{
    public class PairedOrdinalStrategy : IStrategy
    {
        public string SampleType => Constants.SamplesTypes.Paired;

        public string ScaleMeasure => Constants.ScaleMeasures.Ordinal;

        private readonly IWilcoxonSignedRankTest _wilcoxonTest;

        public PairedOrdinalStrategy(IWilcoxonSignedRankTest wilcoxonTest)
        {
            _wilcoxonTest = wilcoxonTest;
        }

        public OutputData Execute(InputData input)
        {
            var pValue = _wilcoxonTest.Calculate(input);

            return OutputData.Success(pValue, Constants.Translations.SamePopulationResult);
        }
    }
}