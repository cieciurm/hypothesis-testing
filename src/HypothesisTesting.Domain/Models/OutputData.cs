namespace HypothesisTesting.Domain.Models
{
    public class OutputData
    {
        public bool HasError { get; set; }

        public string ErrorText { get; set; }

        public double? PValue { get; set; }

        public double? Statistics { get; set; }

        private OutputData()
        {
        }

        public static OutputData Error(string error = "") =>
            new OutputData
            {
                HasError = true,
                ErrorText = error,
            };

        public static OutputData Success(double pValue, double? statistics = null) =>
            new OutputData
            {
                PValue = pValue,
                Statistics = statistics,
            };
    }
}
