using System;
using Accord.Statistics.Distributions;
using Accord.Statistics.Distributions.Univariate;
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
    internal class NormalDistributionTest : INormalDistributionTest
    {
        public const int SampleSize = 50;

        private readonly IExecutionLogger _logger;
        private readonly ITranslator _translator;

        public NormalDistributionTest(IExecutionLogger logger, ITranslator translator)
        {
            _logger = logger;
            _translator = translator;
        }

        public bool IsNormalDistribution(DataSeries dataSeries, double significance)
        {
            var sample = dataSeries.Values;

            if (sample.Length <= SampleSize)
            {
                _logger.AddLog(_translator.Translate(Constants.Translations.DistributionTestMethod, sample.Length, "Shapiro-Wilk"));

                try
                {
                    var swResult = new ShapiroWilkTest(sample);
                    return IsNormalDistribution(swResult, significance);
                }
                catch (Exception)
                {
                    return false;
                }
            }

            _logger.AddLog(_translator.Translate(Constants.Translations.DistributionTestMethod, sample.Length, "Kolmogorov-Smirnov"));

            var ksResult = new KolmogorovSmirnovTest(sample, new KolmogorovSmirnovDistribution(sample.Length));
            return IsNormalDistribution(ksResult, significance);
        }

        private bool IsNormalDistribution<T>(HypothesisTest<T> result, double significance)
            where T : IUnivariateDistribution
        {
            var isNormal = HypothesisHelper.IsHypothesisTrue(result.PValue, significance);
            var isNormalText = _translator.Translate(isNormal.ToString());

            var log = _translator.Translate(Constants.Translations.DistributionTest, result.PValue.Round(), isNormalText);
            _logger.AddLog(log);

            return isNormal;
        }
    }
}
