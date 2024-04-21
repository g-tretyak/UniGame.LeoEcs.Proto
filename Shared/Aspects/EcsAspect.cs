namespace UniGame.LeoEcs.Bootstrap.Runtime.Abstract
{
    using System;
    using System.Runtime.CompilerServices;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime;

#if ENABLE_IL2CPP
    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
#endif
    [Serializable]
    public abstract class EcsAspect : ProtoAspectInject, IEcsAspect
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Initialize(ProtoWorld world) => Init(world);
    }
}