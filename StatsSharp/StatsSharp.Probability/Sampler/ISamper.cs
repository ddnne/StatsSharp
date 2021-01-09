using StatsSharp.Probability.Parameter;
using StatsSharp.Probability.SamplerConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsSharp.Probability.Sampler
{
    public interface ISamper<SamplerConfig, TargetDistributionInputDataType, TargetDistributionParameter>
        where SamplerConfig : SamplerConfigBase<TargetDistributionInputDataType, TargetDistributionParameter>
        where TargetDistributionParameter : IParameter
    {
        IEnumerable<TargetDistributionInputDataType> GetSamples(SamplerConfig samplerConfig);
    }
}
