using Accord.Statistics.Testing;
using HypothesisTesting.Domain;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Statistics;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;

namespace HypothesisTesting.Adapters.AccordNET.Statistics
{
    internal class MannWhitneyTest : IMannWhitneyTest
    {
        private readonly IExecutionLogger _executionLogger;
        private readonly ITranslator _translator;

        public MannWhitneyTest(IExecutionLogger executionLogger, ITranslator translator)
        {
            _executionLogger = executionLogger;
            _translator = translator;
        }

        public double Calculate(InputData inputData)
        {
            var mww = new MannWhitneyWilcoxonTest(inputData.XValues.Values, inputData.YValues.Values, exact: true);

            _executionLogger.AddLog(_translator.Translate(Constants.Translations.ManWhitneyTestMethod));

            return mww.PValue;
        }
    }
}
