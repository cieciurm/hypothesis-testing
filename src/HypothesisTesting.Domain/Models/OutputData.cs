namespace HypothesisTesting.Domain.Models
{
    public class OutputData
    {
        public bool HasError { get; set; }

        public string Error { get; set; }

        public double? PValue { get; set; }

        public double? Statistics { get; set; }
    }
}
