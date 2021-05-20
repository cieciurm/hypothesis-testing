using System;
using System.Linq;
using HypothesisTesting.Domain.Models;
using HypothesisTesting.Domain.Ports.Statistics;

namespace HypothesisTesting.Domain.Statistics
{
    public class ContingencyMatrixCalculator : IContingencyMatrixCalculator
    {
        public int[,] Calculate(InputData inputData)
        {
            var x = inputData.XValues.Values.Select(Convert.ToInt32).ToArray();
            var y = inputData.YValues.Values.Select(Convert.ToInt32).ToArray();

            var intermediate = CreateIntermediate(x.Length, x, y);

            var distinctX = x.Distinct().ToArray();
            var distinctY = y.Distinct().ToArray();

            var contingencyMatrix = new int[distinctX.Length, distinctY.Length];

            for (var i = 0; i < distinctX.Length; i++)
            {
                for (var j = 0; j < distinctY.Length; j++)
                {
                    var currentX = distinctX[i];
                    var currentY = distinctY[j];

                    contingencyMatrix[i, j] = FoundRow(intermediate, currentX, currentY)
                        ? 1
                        : 0;
                }
            }

            return contingencyMatrix;
        }

        private static int[][] CreateIntermediate(int size, int[] x, int[] y)
        {
            var intermediate = new int[size][];
            for (var i = 0; i < size; i++)
            {
                intermediate[i] = new[] { x[i], y[i] };
            }

            return intermediate;
        }

        private static bool FoundRow(int[][] intermediate, int currentX, int currentY)
        {
            var found = false;

            foreach (var row in intermediate)
            {
                if (row[0] == currentX && row[1] == currentY)
                {
                    found = true;
                    break;
                }
            }

            return found;
        }
    }
}
