namespace UniGame.LeoEcs.ViewSystem.Behavriour
{
    using Core.Runtime;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using UniGame.ViewSystem.Runtime;

    public interface IEcsViewModel : IViewModel
    {
        UniTask InitializeAsync(ProtoWorld world, IContext context);
    }
}