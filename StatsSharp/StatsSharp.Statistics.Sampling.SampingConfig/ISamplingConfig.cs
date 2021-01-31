using StatsSharp.Probability.Distribution;
using StatsSharp.Probability.Parameter;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Statistics.Sampling.SamplingConfig
{
    public interface ISamplingConfig<TargetDataType, TargetParameter>
        where TargetParameter : IParameter
    {
        IDistribution<TargetDataType, TargetParameter> TargetDistribution { get; }
        TargetParameter TargetDistParameter { get; }
    }
}
