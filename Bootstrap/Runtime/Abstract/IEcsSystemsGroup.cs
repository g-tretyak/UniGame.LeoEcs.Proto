namespace UniGame.LeoEcs.Bootstrap.Runtime.Abstract
{
    using System.Collections.Generic;
    using Leopotam.EcsLite;

    public interface IEcsSystemsGroup : ILeoEcsFeature
    {
        IReadOnlyList<IEcsSystem> EcsSystems { get; }
        
        void RegisterSystems(List<IEcsSystem> systems);
    }
}