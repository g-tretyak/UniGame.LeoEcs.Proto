namespace Game.Ecs.Core
{
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Feature/Core/Core Late Feature", fileName = "Core Late Feature")]
    public sealed class CoreLateUpdateFeature : BaseLeoEcsFeature
    {
        public override UniTask InitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new AddTransformComponentsSystem());
            ecsSystems.Add(new UpdateTransformDataSystem());
            
            return UniTask.CompletedTask;
        }
    }
}