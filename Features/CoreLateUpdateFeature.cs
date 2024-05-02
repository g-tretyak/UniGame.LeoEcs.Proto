namespace Game.Ecs.Core
{
    using System;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;

    [Serializable]
    public sealed class CoreLateUpdateFeature : EcsFeature
    {
        protected override UniTask OnInitializeAsync(IProtoSystems ecsSystems)
        {

            
            return UniTask.CompletedTask;
        }
    }
}