using Accord.Statistics;
using Accord.Statistics.Testing;
using HypothesisTesting.Domain;
using HypothesisTesting.Domain.Extensions;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Statistics;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;

namespace HypothesisTesting.Adapters.AccordNET.Statistics
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
            var s1 = inputData.XValues.Values;
            var s2 = inputData.YValues.Values;

            var var1 = s1.Variance();
            var var2 = s2.Variance();

            var f = new FTest(var1, var2, s1.Length - 1, s2.Length - 1, TwoSampleHypothesis.ValuesAreDifferent);

            var isVarianceEqual = f.Statistic < f.CriticalValue;

            _executionLogger.AddLog(_translator.Translate(Constants.Translations.SnedecorTestMethod));
            var @true = _translator.Translate(isVarianceEqual.ToString());
            _executionLogger.AddLog(_translator.Translate(Constants.Translations.SnedecorTest, f.PValue.Round(), @true));

            return isVarianceEqual;
        }
    }
}
