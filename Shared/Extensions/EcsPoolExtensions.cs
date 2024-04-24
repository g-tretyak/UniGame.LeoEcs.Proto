namespace UniGame.LeoEcs.Shared.Extensions
{
    using System.Runtime.CompilerServices;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public static class EcsPoolExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryAdd<T>(this ProtoPool<T> pool,ref ProtoPackedEntity packedEntity) where T : struct
        {
            var world = pool.World();
            if (!packedEntity.Unpack(world, out var entity) || pool.Has(entity))
                return false;

            pool.Add(entity);
            return true;
        }
        
#if ENABLE_IL2CPP
        [Il2CppSetOption (Option.NullChecks, false)]
        [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ProtoPool<T> GetPool<T>(this ProtoWorld world) where T : struct
        {
            return world.Pool<T>() as ProtoPool<T>;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryAdd<T>(this ProtoPool<T> pool, ProtoEntity entity) where T : struct
        {
            if (pool.Has(entity)) 
                return false;
            
            pool.Add(entity);
            return true;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryAdd<T>(this ProtoPool<T> pool, int entity) where T : struct
        {
            var protoEntity = (ProtoEntity)entity;
            return TryAdd(pool, protoEntity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T Add<T>(this ProtoPool<T> pool, int entity) where T : struct
        {
            var protoEntity = (ProtoEntity)entity;
            return ref pool.Add(protoEntity);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGet<T>(this ProtoPool<T> pool, int entity, ref T component) where T : struct
        {
            var protoEntity = (ProtoEntity)entity;
            return TryGet(pool, protoEntity, ref component);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGet<T>(this ProtoPool<T> pool, ProtoEntity entity, ref T component) where T : struct
        {
            if (!pool.Has(entity)) 
                return false;
            
            component = ref pool.Get(entity);
            return true;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRemove<T>(this ProtoPool<T> pool, ProtoPackedEntity packedEntity)
            where T : struct
        {
            var world = pool.World();
            return packedEntity.Unpack(world, out var entity) && TryRemove<T>(pool, entity);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRemove<T>(this ProtoPool<T> pool, ProtoEntity entity) where T : struct
        {
            if (!pool.Has(entity))
                return false;
            
            pool.Del(entity);
            return true;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryAdd<T>(this ProtoPool<T> pool, ProtoPackedEntity packedEntity, ref T component) where T : struct
        {
            var world = pool.World();
            if (!packedEntity.Unpack(world, out var entity))
                return false;
            component = ref pool.Add(entity);
            return true;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref TComponent GetOrAddComponent<TComponent>(this ProtoPool<TComponent> pool, ProtoEntity entity)
            where TComponent : struct
        {
            ref var component = ref pool.Has(entity) 
                ? ref pool.Get(entity) 
                : ref pool.Add(entity);
            return ref component;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref TComponent GetOrAddComponent<TComponent>(this ProtoPool<TComponent> pool, int entity)
            where TComponent : struct
        {
            return ref pool.GetOrAddComponent((ProtoEntity)entity);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref TComponent GetOrAddComponent<TComponent>(this EcsPool<TComponent> pool, ProtoEntity entity)
            where TComponent : struct
        {
            return ref pool.pool.GetOrAddComponent(entity);
        }
    }
}