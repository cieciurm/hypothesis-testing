using Accord.Statistics.Testing;
using HypothesisTesting.Domain;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Statistics;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;

namespace HypothesisTesting.Adapters.AccordNET.Statistics
{
    /// <summary>
    /// https://www.socscistatistics.com/tests/studentttest/default.aspx
    /// </summary>
    internal class StudentTest : IStudentTest
    {
        private readonly IExecutionLogger _executionLogger;
        private readonly ITranslator _translator;

        public StudentTest(IExecutionLogger executionLogger, ITranslator translator)
        {
            _executionLogger = executionLogger;
            _translator = translator;
        }

        public double Calculate(InputData inputData, bool equalVariance)
        {
            var s1 = inputData.XValues.Values;
            var s2 = inputData.YValues.Values;

            if (equalVariance)
            {
                _executionLogger.AddLog(_translator.Translate(Constants.Translations.StudentIndependentWithEqualVariancesTestMethod));
            }
            else
            {
                _executionLogger.AddLog(_translator.Translate(Constants.Translations.StudentIndependentWithNotEqualVariancesTestMethod));
            }

            var t = new TwoSampleTTest(s1, s2, equalVariance);

            return t.PValue;
        }
    }
}
