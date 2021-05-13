using System.Collections.Generic;
using System.Linq;

namespace HypothesisTesting.Domain.Models
{
    public class DataSeries
    {
        public double[] Values { get; }

        public DataSeries(IEnumerable<double> values)
        {
            Values = values.ToArray();
        }
    }
}
