namespace UniGame.LeoEcs.Bootstrap.Runtime.Abstract
{
    using UniGame.GameFlow.Runtime.Interfaces;
    using Leopotam.EcsProto;

    public interface IEcsService : IGameService
    {

        ProtoWorld World { get; }
        
        public void SetDefaultWorld(ProtoWorld world);

    }
}