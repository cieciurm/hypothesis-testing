using System.Collections.Generic;

namespace HypothesisTesting.Domain.Services
{
    public interface IExecutionLogger
    {
        void AddLog(string log);

        IEnumerable<string> GetLog();
    }

    public class ExecutionLogger : IExecutionLogger
    {
        private readonly ICollection<string> _log;

        public ExecutionLogger()
        {
            _log = new List<string>();
        }

        public void AddLog(string log)
        {
            _log.Add(log);
        }

        public IEnumerable<string> GetLog()
        {
            return _log;
        }
    }
}
