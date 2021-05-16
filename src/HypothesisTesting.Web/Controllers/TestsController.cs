using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;
using HypothesisTesting.Web.Infrastructure.Input;
using HypothesisTesting.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static HypothesisTesting.Web.WebConstants;

namespace HypothesisTesting.Web.Controllers
{
    public class TestsController : Controller
    {
        private readonly IExecutor _executor;
        private readonly IExecutionLogger _executionLogger;
        private readonly ITranslator _translator;
        private readonly ILanguageProvider _languageProvider;
        private readonly IConfiguration _configuration;

        public TestsController(IExecutor executor, IExecutionLogger executionLogger, ITranslator translator, ILanguageProvider languageProvider, IConfiguration configuration)
        {
            _executor = executor;
            _executionLogger = executionLogger;
            _translator = translator;
            _languageProvider = languageProvider;
            _configuration = configuration;
        }

        public IActionResult Index(string language)
        {
            language ??= Languages.Polish;
            _languageProvider.SetLanguage(language);

            var viewModel = new TestViewModel(language, _translator, _configuration);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Submit(TestDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.XValues) || string.IsNullOrWhiteSpace(dto.YValues))
            {
                return PartialView("Results", TestResultViewModel.ToErrorViewModel(dto.Language, _translator, dto, _executionLogger, Translations.ErrorIncorrectData));
            }

            if (!InputParser.TryParse(dto.XValues, out var x) || !InputParser.TryParse(dto.YValues, out var y))
            {
                return PartialView("Results", TestResultViewModel.ToErrorViewModel(dto.Language, _translator, dto, _executionLogger, Translations.ErrorIncorrectDataSize));
            }

            if (!InputValidator.IsValid(dto.SamplesType, x, y))
            {
                return PartialView("Results", TestResultViewModel.ToErrorViewModel(dto.Language, _translator, dto, _executionLogger, Translations.ErrorPairedDataMustHaveSameSize));
            }

            var inputData = new InputData(x, y, dto.SamplesType, dto.ScaleMeasure, dto.Significance);
            var outputData = _executor.Execute(inputData);
            var viewModel = TestResultViewModel.ToViewModel(dto.Language, _translator, dto, outputData, _executionLogger);

            return PartialView("Results", viewModel);
        }
    }
}
