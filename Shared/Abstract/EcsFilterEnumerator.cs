namespace UniGame.LeoEcs.Shared.Extensions
{
    using System.Runtime.CompilerServices;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
#endif
    public readonly ref struct EcsFilterEnumerator {
        readonly EcsFilter _it;

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public EcsFilterEnumerator (EcsFilter it) {
            _it = it;
            _it.it.Begin ();
        }

        public ProtoEntity Current {
            [MethodImpl (MethodImplOptions.AggressiveInlining)]
            get => _it.Entity ();
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public bool MoveNext () => _it.it.Next ();

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Dispose () => _it.it.End ();
    }
}