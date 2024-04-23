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
        protected override UniTask OnInitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new AddTransformComponentsSystem());
            ecsSystems.Add(new UpdateTransformDataSystem());
            
            return UniTask.CompletedTask;
        }
    }
}