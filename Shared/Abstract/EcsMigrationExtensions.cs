namespace UniGame.LeoEcs.Shared.Extensions
{
    using System.Runtime.CompilerServices;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;

    public static class EcsMigrationExtensions
    {
        public static EcsFilter Filter<TComponent>(this ProtoWorld world)
            where TComponent : struct
        {
            return new EcsFilter().Filter<TComponent>(world);
        }
                
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ProtoWorld GetWorld(this IProtoSystems systems)
        {
            return systems.World();
        }
        
        public static EcsFilter End(this EcsFilter filter)
        {
            return filter.EndFilter();
        }
        
                
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static EcsFilterEnumerator GetEnumerator (this EcsFilter filter)
        {
            return new EcsFilterEnumerator (filter);
        }

    }
    
#if ENABLE_IL2CPP
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