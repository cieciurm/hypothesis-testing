using System.Collections.Generic;
using System.Linq;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Strategies;

namespace HypothesisTesting.Domain.Services
{
    public interface IExecutor
    {
        OutputData Execute(InputData inputData);
    }

    public class Executor : IExecutor
    {
        private readonly IEnumerable<IStrategy> _strategies;
        private readonly IExecutionLogger _logger;
        private readonly ITranslator _translator;

        public Executor(IEnumerable<IStrategy> strategies, IExecutionLogger logger, ITranslator translator)
        {
            _strategies = strategies;
            _logger = logger;
            _translator = translator;
        }

        public OutputData Execute(InputData inputData)
        {
            var strategy = _strategies.SingleOrDefault(x => x.ScaleMeasure == inputData.ScaleMeasure && x.SampleType == inputData.SampleType);

            var sampleType = _translator.Translate(inputData.SampleType);
            var scaleMeasure = _translator.Translate(inputData.ScaleMeasure);
            var log = _translator.Translate(Constants.Translations.SelectingStrategy, sampleType, scaleMeasure);
            _logger.AddLog(log);

            if (strategy == null)
            {
                var notFoundLog = _translator.Translate(Constants.Translations.StrategyNotFound);
                _logger.AddLog(notFoundLog);
                return OutputData.Error();
            }

            return strategy.Execute(inputData);
        }
    }
}