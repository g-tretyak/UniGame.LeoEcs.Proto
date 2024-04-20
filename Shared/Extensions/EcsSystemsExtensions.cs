using UniGame.LeoEcs.Shared.Systems;

namespace UniGame.LeoEcs.Shared.Extensions
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using Game.Modules.UnioModules.UniGame.LeoEcsLite.LeoEcs.Shared.Systems;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Proto.Shared;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    public static class LeoEcsExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEcsSystems CreateOn<TTrigger,TTarget>(this IEcsSystems systems)
            where TTrigger : struct
            where TTarget : struct
        {
            systems.AddSystem(new SelfConvertComponentSystem<TTrigger,TTarget>());
            return systems;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int First(this EcsFilter filter)
        {
            foreach (var entity in filter)
                return (int)entity;

            return -1;
        }
        
        public static IEcsSystems FireOn<TFilter,TComponent>(this IEcsSystems systems)
            where TFilter : struct
            where TComponent : struct
        {
            systems.AddSystem(new FireOnSystem<TFilter,TComponent>());
            return systems;
        }
        
        public static IEcsSystems FireOn<TFilter1,TFilter2,TComponent>(this IEcsSystems systems)
            where TFilter1 : struct
            where TFilter2 : struct
            where TComponent : struct
        {
            systems.AddSystem(new FireOnSystem<TFilter1,TFilter2,TComponent>());
            return systems;
        }
        
        public static void FireOn<TFilter1,TFilter2,TFilter3,TComponent>(this IEcsSystems systems)
            where TFilter1 : struct
            where TFilter2 : struct
            where TFilter3 : struct
            where TComponent : struct
        {
            systems.AddSystem(new FireOnSystem<TFilter1,TFilter2,TFilter3,TComponent>());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EntityHasAll<T1, T2>(this EcsWorld world,int entity)
            where T1 : struct
            where T2 : struct
        {
            var pool1 = world.GetPool<T1>();
            var pool2 = world.GetPool<T2>();

            return pool1.Has((ProtoEntity)entity) && pool2.Has((ProtoEntity)entity);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EntityHasAll<T1, T2>(this EcsWorld world,ProtoEntity entity)
            where T1 : struct
            where T2 : struct
        {
            var pool1 = world.GetPool<T1>();
            var pool2 = world.GetPool<T2>();

            return pool1.Has(entity) && pool2.Has(entity);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EntityHasAll<T1, T2,T3>(this EcsWorld world,ProtoEntity entity)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            var pool1 = world.GetPool<T1>();
            var pool2 = world.GetPool<T2>();
            var pool3 = world.GetPool<T3>();

            return pool1.Has(entity) && pool2.Has(entity) && pool3.Has(entity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EntityHasAll<T1, T2,T3,T4>(this EcsWorld world,ProtoEntity entity)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            var pool1 = world.GetPool<T1>();
            var pool2 = world.GetPool<T2>();
            var pool3 = world.GetPool<T3>();
            var pool4 = world.GetPool<T4>();

            return pool1.Has(entity) && pool2.Has(entity) && pool3.Has(entity) && pool4.Has(entity);
        }
        
        public static EcsFilter GetFilter<TComponent>(this IEcsSystems IEcsSystems)
            where TComponent : struct
        {
            var world = IEcsSystems.GetWorld();
            var filter = world.Filter<TComponent>().End();

            return filter;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ProtoPool<TComponent> GetPool<TComponent>(this IEcsSystems IEcsSystems)
            where TComponent : struct
        {
            var world = IEcsSystems.GetWorld();
            var pool = world.GetPool<TComponent>();

            return pool;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRemoveComponent<TComponent>(this IEcsSystems systems, ProtoEntity entity)
            where TComponent : struct
        {
            var world = systems.GetWorld();
            return world.TryRemoveComponent<TComponent>(entity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRemoveComponent<TComponent>(this IEcsSystems systems, int entity)
            where TComponent : struct
        {
            var entityProto = (ProtoEntity)entity;
            return TryRemoveComponent<TComponent>(systems, entityProto);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref TComponent GetComponent<TComponent>(this IEcsSystems systems, ProtoEntity entity)
            where TComponent : struct
        {
            var world = systems.GetWorld();
            var pool = world.GetPool<TComponent>();
            return ref pool.Get(entity);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref TComponent GetComponent<TComponent>(this IEcsSystems systems, int entity)
            where TComponent : struct
        {
            return ref GetComponent<TComponent>(systems, (ProtoEntity)entity);
        }
        
        public static ref TComponent AddComponent<TComponent>(this IEcsSystems systems, ProtoEntity entity)
            where TComponent : struct
        {
            var world = systems.GetWorld();
            return ref world.AddComponent<TComponent>(entity);
        }

        public static ref TComponent AddComponent<TComponent>(this IEcsSystems systems, int entity)
            where TComponent : struct
        {
            return ref AddComponent<TComponent>(systems, (ProtoEntity)entity);
        }
        
        public static IEcsSystems Add(this IEcsSystems ecsSystems, IEnumerable<IEcsSystem> systems)
        {
            foreach (var system in systems)
                ecsSystems.AddSystem(system);

            return ecsSystems;
        }
    }
}
