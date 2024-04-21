namespace Game.Ecs.Time
{
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Feature/Game Time Feature", fileName = "Game Time Feature")]
    public class GameTimeFeature : BaseLeoEcsFeature
    {
        public override UniTask InitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new UpdateEntityTimeSystem());
            return UniTask.CompletedTask;
        }
    }
}
