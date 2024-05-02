namespace Game.Ecs.Time
{
    using System;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;

    [Serializable]
    public class GameTimeFeature : EcsFeature
    {
        protected override UniTask OnInitializeAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new UpdateEntityTimeSystem());
            return UniTask.CompletedTask;
        }
    }
}
