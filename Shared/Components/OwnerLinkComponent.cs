using System;
using Leopotam.EcsLite;

namespace UniGame.LeoEcs.Shared.Components
{
    using Leopotam.EcsProto.QoL;

    /// <summary>
    /// link to owner entity, but don't destroy on owner destroy
    /// </summary>
    [Serializable]
    public struct OwnerLinkComponent
    {
        public ProtoPackedEntity Value;
    }
    
    [Serializable]
    public struct LinkComponent<T>
    {
        public ProtoPackedEntity Value;
    }
    
    [Serializable]
    public struct LinkComponent
    {
        public ProtoPackedEntity Value;
    }
    
    [Serializable]
    public struct ValueLinkComponent<T>
    {
        public T Value;
    }
}