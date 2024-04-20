namespace Leopotam.EcsLite
{
    using System.Runtime.CompilerServices;
    using EcsProto;
#if ENABLE_IL2CPP
    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
#endif
    public struct EcsWorld
    {
        public ProtoWorld Value;
        
        public static implicit operator ProtoWorld(EcsWorld world) => world.Value;
        
        public static implicit operator EcsWorld(ProtoWorld world) => new EcsWorld() { Value = world };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsAlive() => Value!= null && Value.IsAlive();
    }
}