namespace UniGame.LeoEcs.Shared.Extensions
{
    using System.Runtime.CompilerServices;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;

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
}