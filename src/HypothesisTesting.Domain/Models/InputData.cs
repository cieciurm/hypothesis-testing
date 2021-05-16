namespace HypothesisTesting.Domain.Models
{
    public class InputData
    {
        public DataSeries XValues { get; }

        public DataSeries YValues { get; }

        public string SampleType { get; }

        public string ScaleMeasure { get; }

        public double Significance { get; }

        public InputData(DataSeries xValues, DataSeries yValues, string sampleType, string scaleMeasure, double significance)
        {
            XValues = xValues;
            YValues = yValues;
            SampleType = sampleType;
            ScaleMeasure = scaleMeasure;
            Significance = significance;
        }

        public InputData(double[] s1, double[] s2)
        {
            XValues = new DataSeries(s1);
            YValues = new DataSeries(s2);
            Significance = Constants.DefaultSignificance;
        }
    }
}
