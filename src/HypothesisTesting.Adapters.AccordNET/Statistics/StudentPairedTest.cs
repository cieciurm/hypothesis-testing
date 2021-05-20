using Accord.Statistics.Testing;
using HypothesisTesting.Domain;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Statistics;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;

namespace HypothesisTesting.Adapters.AccordNET.Statistics
{
    public class StudentPairedTest : IStudentPairedTest
    {
        private readonly IExecutionLogger _executionLogger;
        private readonly ITranslator _translator;

        public StudentPairedTest(IExecutionLogger executionLogger, ITranslator translator)
        {
            _executionLogger = executionLogger;
            _translator = translator;
        }

        public double Calculate(InputData inputData)
        {
            var s1 = inputData.XValues.Values;
            var s2 = inputData.YValues.Values;

            _executionLogger.AddLog(_translator.Translate(Constants.Translations.StudentPairedTestMethod));

            var t = new PairedTTest(s1, s2)
            {
                Size = inputData.Significance
            };

            return t.PValue;
        }
    }
}
