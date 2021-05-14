using System;
using System.Globalization;
using System.Linq;
using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Web.Infrastructure.Input
{
    public static class InputParser
    {
        public static DataSeries Parse(string val)
        {
            var splitted = val.Split(new[] { ',', ';', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var sample = splitted.Select(x => Convert.ToDouble(x, CultureInfo.InvariantCulture));

            return new DataSeries(sample);
        }
    }
}
