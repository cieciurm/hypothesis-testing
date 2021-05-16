using CenterSpace.NMath.Core;
using HypothesisTesting.Domain;
using HypothesisTesting.Domain.Extensions;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Statistics;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;

namespace HypothesisTesting.Adapters.NMath.Statistics
{
    internal class SnedecorTest : ISnedecorTest
    {
        private readonly IExecutionLogger _executionLogger;
        private readonly ITranslator _translator;

        public SnedecorTest(IExecutionLogger executionLogger, ITranslator translator)
        {
            _executionLogger = executionLogger;
            _translator = translator;
        }

        public bool IsVarianceEqual(InputData inputData, double significance)
        {
            var s1 = StatsFunctions.StandardDeviation(new DoubleVector(inputData.XValues.Values));
            var s2 = StatsFunctions.StandardDeviation(new DoubleVector(inputData.YValues.Values));

            var f = new TwoSampleFTest(s1, inputData.XValues.Values.Length, s2, inputData.YValues.Values.Length, significance, HypothesisType.TwoSided);

            var isVarianceEqual = HypothesisHelper.IsHypothesisTrue(f.P, significance);

            _executionLogger.AddLog(_translator.Translate(Constants.Translations.SnedecorTestMethod));
            var @true = _translator.Translate(isVarianceEqual.ToString());
            _executionLogger.AddLog(_translator.Translate(Constants.Translations.SnedecorTest, f.P.Round(), @true));

            return isVarianceEqual;
        }
    }
}
