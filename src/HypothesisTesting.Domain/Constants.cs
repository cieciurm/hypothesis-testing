namespace HypothesisTesting.Domain
{
    public static class Constants
    {
        public static class SamplesTypes
        {
            public const string Paired = nameof(Paired);
            public const string Independent = nameof(Independent);
        }

        public static class ScaleMeasures
        {
            public const string Nominal = nameof(Nominal);
            public const string Ordinal = nameof(Ordinal);
            public const string Interval = nameof(Interval);
        }

        public static class Translations
        {
            public const string DistributionTest = nameof(DistributionTest);
            public const string DistributionTestMethod = nameof(DistributionTestMethod);
            public const string SnedecorTestMethod = nameof(SnedecorTestMethod);
            public const string SnedecorTest = nameof(SnedecorTest);
            public const string ManWhitneyTestMethod = nameof(ManWhitneyTestMethod);
            public const string TStudentIndependentTestMethod = nameof(TStudentIndependentTestMethod);
            public const string TStudentDependentTestMethod = nameof(TStudentDependentTestMethod);

            public const string StrategyNotFound = nameof(StrategyNotFound);
            public const string SelectingStrategy = nameof(SelectingStrategy);
        }
    }
}
