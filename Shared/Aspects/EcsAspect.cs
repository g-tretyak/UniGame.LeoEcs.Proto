namespace UniGame.LeoEcs.Bootstrap.Runtime.Abstract
{
    using System;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime;

#if ENABLE_IL2CPP
    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
#endif
    [Serializable]
    public abstract class EcsAspect : ProtoAspectInject, IEcsAspect
    {
        
    }
}