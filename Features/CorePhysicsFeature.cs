namespace Game.Ecs.Core
{
    using Systems;
    using Cysharp.Threading.Tasks;
    using JetBrains.Annotations;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;

    [UsedImplicitly]
    public sealed class CorePhysicsFeature : LeoEcsSystemAsyncFeature
    {
        public override UniTask InitializeAsync(IProtoSystems ecsSystems)
        {
            ecsSystems.Add(new UpdateGroundInfoSystem());
            
            return UniTask.CompletedTask;
        }
    }
}