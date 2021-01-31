using StatsSharp.Probability.Parameter;
using StatsSharp.Statistics.Sampling.SamplingConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Statistics.Sampling.SamplingMethod
{
    public interface ISamplingMethod<SamplerConfig, TargetDistributionInputDataType, TargetDistributionParameter>
        where SamplerConfig : SamplingConfigBase<TargetDistributionInputDataType, TargetDistributionParameter>
        where TargetDistributionParameter : IParameter
    {
        IEnumerable<TargetDistributionInputDataType> GetSamples(SamplerConfig samplerConfig);
    }
}
