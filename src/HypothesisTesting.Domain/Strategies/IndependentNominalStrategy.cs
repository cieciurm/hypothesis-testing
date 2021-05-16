using static HypothesisTesting.Domain.Constants;

namespace HypothesisTesting.Domain.Strategies
{
    public class IndependentNominalStrategy : BaseNominalStrategy
    {
        public override string SampleType => SamplesTypes.Independent;
    }
}
