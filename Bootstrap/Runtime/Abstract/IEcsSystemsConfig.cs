namespace UniGame.LeoEcs.Bootstrap.Runtime.Abstract
{
    using System.Collections.Generic;
    using Ecs.Bootstrap.Runtime.Config;

    public interface IEcsSystemsConfig
    {
        IReadOnlyList<EcsConfigGroup> FeatureGroups { get; }
    }
}