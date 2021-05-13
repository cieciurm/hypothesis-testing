using System.Collections.Generic;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;

namespace HypothesisTesting.Web.Models
{
    public class TestResultViewModel : BaseViewModel
    {
        public IEnumerable<string> Logs { get; set; }

        public bool HasError { get; set; }

        public double? PValue { get; set; }

        public double? Statistics { get; set; }

        public TestResultViewModel(string language, ITranslator translator)
            : base(language, translator)
        {
        }

        public static TestResultViewModel ToViewModel(string language, ITranslator translator, OutputData outputData, IExecutionLogger executionLogger)
        {
            var viewModel = new TestResultViewModel(language, translator)
            {
                Logs = executionLogger.GetLog(),
                HasError = outputData.HasError,
                PValue = outputData.PValue,
                Statistics = outputData.Statistics,
            };

            return viewModel;
        }

        public static TestResultViewModel ToErrorViewModel(string language, ITranslator translator, IExecutionLogger executionLogger)
        {
            var viewModel = new TestResultViewModel(language, translator)
            {
                Logs = executionLogger.GetLog(),
                HasError = true,
            };

            return viewModel;
        }
    }
}
