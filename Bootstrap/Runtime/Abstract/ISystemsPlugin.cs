namespace UniGame.LeoEcs.Bootstrap.Runtime.Abstract
{
    using System;
    using Leopotam.EcsProto;

    public interface ISystemsPlugin : IDisposable
    {
        bool IsActive { get; }

        void Execute(ProtoWorld world);

        void Add(IProtoSystems systems);

        void Stop();
    }
}