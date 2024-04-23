namespace UniGame.LeoEcs.Bootstrap.Runtime.Abstract
{
    using System;
    using Leopotam.EcsProto;

    public interface IEcsExecutor : IDisposable
    {
        bool IsActive { get; }

        void Execute(ProtoWorld world);

        void Add(IProtoSystems systems);

        void Stop();
    }
}