using System;
using System.Globalization;
using System.Linq;
using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Web.Infrastructure.Input
{
    public static class InputParser
    {
        public static bool TryParse(string val, out DataSeries dataSeries)
        {
            try
            {
                var sample = val
                    .Trim()
                    .Split(new[] {',', ';', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => Convert.ToDouble(x, CultureInfo.InvariantCulture))
                    .ToList();

                dataSeries = new DataSeries(sample);

                return sample.Count >= 5;
            }
            catch (Exception)
            {
                dataSeries = new DataSeries(Array.Empty<double>());

                return false;
            }
        }
    }
}
