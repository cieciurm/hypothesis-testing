using System.Linq;
using Accord.Statistics;
using Accord.Statistics.Testing;
using HypothesisTesting.Domain;
using HypothesisTesting.Domain.Extensions;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Statistics;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;
using HypothesisTesting.Domain.Statistics;

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

            var f = new FTest(var1, var2, s1.Length - 1, s2.Length - 1, TwoSampleHypothesis.ValuesAreDifferent)
            {
                Size = significance
            };

            var pValue = PValueCalculator.Calculate(f);

            var isVarianceEqual = HypothesisHelper.IsHypothesisTrue(pValue, significance);

            _executionLogger.AddLog(_translator.Translate(Constants.Translations.SnedecorTestMethod));
            var @true = _translator.Translate(isVarianceEqual.ToString());
            _executionLogger.AddLog(_translator.Translate(Constants.Translations.SnedecorTest, f.PValue.Round(), @true));

            return isVarianceEqual;
        }

        internal class PValueCalculator
        {
            public static double Calculate(FTest f)
            {
                var p = f.StatisticDistribution.DistributionFunction(f.Statistic);
                var complementary = f.StatisticDistribution.ComplementaryDistributionFunction(f.Statistic);

                var min = new[] { p, complementary }.Min();
                var pValue = 2 * min;

                return pValue;
            }
        }
    }
}
