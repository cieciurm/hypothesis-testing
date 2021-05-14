using System.Collections.Generic;
using System.Linq;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;

namespace HypothesisTesting.Web.Models
{
    public class TestResultViewModel : BaseViewModel
    {
        public IList<string> Logs { get; set; }

        public bool HasError { get; set; }

        public string PValue { get; set; }

        public double? Statistics { get; set; }

        public TestResultViewModel(string language, ITranslator translator)
            : base(language, translator)
        {
        }

        public static TestResultViewModel ToViewModel(string language, ITranslator translator, OutputData outputData, IExecutionLogger executionLogger)
        {
            var viewModel = new TestResultViewModel(language, translator)
            {
                Logs = executionLogger.GetLog().ToList(),
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
                Logs = executionLogger.GetLog().ToList(),
                HasError = true,
            };

            return viewModel;
        }
    }
}
