namespace UniGame.LeoEcs.Bootstrap.Runtime.Abstract
{
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;

    public interface ILeoEcsInitializableFeature
    {
        UniTask InitializeAsync(IProtoSystems ecsSystems);
    }
}