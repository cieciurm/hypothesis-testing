using System.Collections.Generic;
using System.Linq;
using HypothesisTesting.Domain.Extensions;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Translations;
using HypothesisTesting.Domain.Statistics;
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
            LogStrategy(inputData);

            var strategy = _strategies.SingleOrDefault(x => x.ScaleMeasure == inputData.ScaleMeasure &&
                                                            x.SampleType == inputData.SampleType);

            if (strategy == null)
            {
                var notFoundLog = _translator.Translate(Constants.Translations.StrategyNotFound);
                _logger.AddLog(notFoundLog);
                return OutputData.Error();
            }

            var outputData = strategy.Execute(inputData);

            LogResult(inputData, outputData);

            return outputData;
        }

        private void LogStrategy(InputData inputData)
        {
            var sampleType = _translator.Translate(inputData.SampleType);
            var scaleMeasure = _translator.Translate(inputData.ScaleMeasure);
            var log = _translator.Translate(Constants.Translations.SelectingStrategy, sampleType, scaleMeasure);
            _logger.AddLog(log);
        }

        private void LogResult(InputData inputData, OutputData outputData)
        {
            if (outputData.HasError)
            {
                return;
            }

            var @true = _translator.Translate(HypothesisHelper.IsHypothesisTrue(outputData.PValue, inputData.Significance).ToString());
            var resultLog = _translator.Translate(Constants.Translations.Result, outputData.PValue.Round(), @true);
            _logger.AddLog(resultLog);
        }
    }
}