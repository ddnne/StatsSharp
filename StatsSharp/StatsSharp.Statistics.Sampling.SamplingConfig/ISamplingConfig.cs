using StatsSharp.Probability.Distribution;
using StatsSharp.Probability.Parameter;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Statistics.Sampling.SamplingConfig
{
    public interface ISamplingConfig<TargetDist, TargetDistributionInputDataType, TargetDistributionParameter>
        where TargetDist :
            IDistribution<TargetDistributionInputDataType, TargetDistributionParameter>,
            IHasProbabilityDensityFunction<TargetDistributionInputDataType, TargetDistributionParameter>
        where TargetDistributionParameter : IParameter
    {
        TargetDist TargetDistribution { get; }
        TargetDistributionParameter TargetDistParameter { get; }
        int Count { get; }
    }
}
