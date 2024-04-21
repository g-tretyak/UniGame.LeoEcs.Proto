namespace UniGame.LeoEcs.Bootstrap.Runtime.Abstract
{
    using UniGame.GameFlow.Runtime.Interfaces;
    using System;
    using Converter.Runtime;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;

    public interface ILeoEcsService : IGameService
    {

        ProtoWorld World { get; }
        
        public void SetDefaultWorld(ProtoWorld world);

    }
}