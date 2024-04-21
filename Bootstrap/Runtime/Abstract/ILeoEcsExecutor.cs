namespace UniGame.LeoEcs.Bootstrap.Runtime.Abstract
{
    using System;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;

    public interface ILeoEcsExecutor : IDisposable
    {
        bool IsActive { get; }

        void Execute(ProtoWorld world);

        void Add(IProtoSystems systems);

        void Stop();
    }
}