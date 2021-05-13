using System;
using System.Linq;
using HypothesisTesting.Domain.Models;

namespace HypothesisTesting.Web.Infrastructure.Input
{
    public static class InputParser
    {
        public static DataSeries Parse(string val)
        {
            var splitted = val.Split(new[] { ',', ';', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var sample = splitted.Select(Convert.ToDouble);

            return new DataSeries(sample);
        }
    }
}
