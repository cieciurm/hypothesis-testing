using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Services;
using HypothesisTesting.Web.Infrastructure.Input;
using HypothesisTesting.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
            language ??= WebConstants.Languages.Polish;
            _languageProvider.SetLanguage(language);

            var viewModel = new TestViewModel(language, _translator, _configuration);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Submit(TestDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.XValues) || string.IsNullOrWhiteSpace(dto.YValues))
            {
                return PartialView("Results", TestResultViewModel.ToErrorViewModel(dto.Language, _translator, _executionLogger));
            }

            var x = InputParser.Parse(dto.XValues);
            var y = InputParser.Parse(dto.YValues);

            var outputData = _executor.Execute(new InputData(x, y, dto.SamplesType, dto.ScaleMeasure));
            var viewModel = TestResultViewModel.ToViewModel(dto.Language, _translator, outputData, _executionLogger);

            return PartialView("Results", viewModel);
        }
    }
}
