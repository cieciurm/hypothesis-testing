namespace HypothesisTesting.Domain.Models
{
    public class InputData
    {
        public DataSeries XValues { get; }

        public DataSeries YValues { get; }

        public string SampleType { get; }

        public string ScaleMeasure { get; }

        public InputData(DataSeries xValues, DataSeries yValues, string sampleType, string scaleMeasure)
        {
            XValues = xValues;
            YValues = yValues;
            SampleType = sampleType;
            ScaleMeasure = scaleMeasure;
        }

        public InputData(double[] s1, double[] s2)
        {
            XValues = new DataSeries(s1);
            YValues = new DataSeries(s2);
        }
    }
}
