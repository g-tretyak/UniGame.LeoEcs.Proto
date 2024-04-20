namespace Leopotam.EcsLite
{
    using System;
    using System.Runtime.CompilerServices;
    using EcsProto.QoL;
#if ENABLE_IL2CPP
    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
#endif
    [Serializable]
    public struct EcsPackedEntity : IEquatable<ProtoPackedEntity> {
        
        public ProtoPackedEntity Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Value.GetHashCode();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ProtoPackedEntity rhs) => Value.Equals(rhs);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ProtoPackedEntity(EcsPackedEntity packed) => packed.Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator EcsPackedEntity(ProtoPackedEntity packed) => new EcsPackedEntity() { Value = packed };
        
    }
}