namespace HypothesisTesting.Domain.Ports.Statistics
{
    /// <summary>
    /// https://www.graphpad.com/quickcalcs/McNemar1.cfm
    /// </summary>
    public interface IMcNemarTest
    {
        double Calculate(int[,] contingencyMatrix, double significance);
    }
}