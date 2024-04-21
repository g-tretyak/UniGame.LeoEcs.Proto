namespace Leopotam.EcsLite
{
    using System.Runtime.CompilerServices;
    using EcsProto;
    
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
#endif
    public readonly ref struct ItEmptyEnumerator
    {
        public ProtoEntity Current => default;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext() => false;

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Dispose () {}
    }
    
}