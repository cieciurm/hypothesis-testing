using System.Collections.Generic;
using System.Linq;
using HypothesisTesting.Domain.Extensions;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;

namespace HypothesisTesting.Web.Models
{
    public class TestResultViewModel : BaseViewModel
    {
        public string XValues { get; set; }

        public string  YValues { get; set; }

        public IList<string> Logs { get; set; }

        public bool HasError { get; set; }

        public string Error { get; set; }

        public double Significance { get; set; }

        public TestResultViewModel(string language, ITranslator translator)
            : base(language, translator)
        {
        }

        public static TestResultViewModel ToViewModel(string language, ITranslator translator, TestDto testDto, OutputData outputData, IExecutionLogger executionLogger)
        {
            var viewModel = new TestResultViewModel(language, translator)
            {
                Logs = executionLogger.GetLog().ToList(),
                HasError = outputData.HasError,
                Error = outputData.ErrorText,
                XValues = testDto.XValues,
                YValues = testDto.YValues,
                Significance = testDto.Significance,
            };

            return viewModel;
        }

        public static TestResultViewModel ToErrorViewModel(TestDto dto, ITranslator translator, IExecutionLogger executionLogger, string errorKey = null)
        {
            var viewModel = new TestResultViewModel(dto.Language, translator)
            {
                Logs = executionLogger.GetLog().ToList(),
                HasError = true,
                XValues = dto.XValues,
                YValues = dto.YValues,
                Significance = dto.Significance,
                Error = string.IsNullOrWhiteSpace(errorKey) ? string.Empty : translator.Translate(errorKey),
            };

            return viewModel;
        }
    }
}
