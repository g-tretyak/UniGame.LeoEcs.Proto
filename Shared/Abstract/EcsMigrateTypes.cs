namespace Leopotam.EcsLite
{
    using System.Runtime.CompilerServices;
    using Leopotam.EcsProto;

#if ENABLE_IL2CPP
    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
#endif
    public interface IEcsSystem : IProtoSystem { }
    
#if ENABLE_IL2CPP
    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
#endif
    public interface IEcsSystems : IProtoSystems { }

#if ENABLE_IL2CPP
    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
#endif
    public interface IEcsRunSystem : IEcsSystem,IProtoRunSystem { }
    
#if ENABLE_IL2CPP
    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
#endif
    public interface IEcsInitSystem : IEcsSystem,IProtoInitSystem { }
    
#if ENABLE_IL2CPP
    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
#endif
    public interface IEcsDestroySystem : IEcsSystem,IProtoDestroySystem { }

#if ENABLE_IL2CPP
    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
#endif
    public struct EcsPool<TComponent>  where TComponent : struct
    {
        public ProtoPool<TComponent> pool;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator EcsPool<TComponent>(ProtoPool<TComponent> pool) => new EcsPool<TComponent>() { pool = pool };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ProtoPool<TComponent>(EcsPool<TComponent> pool) => pool.pool;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => pool == null ? 0 :pool.GetHashCode();
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Has(ProtoEntity entity) => pool.Has(entity);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref TComponent Add(ProtoEntity entity) => ref pool.Add(entity);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref TComponent Get(ProtoEntity entity) => ref pool.Get(entity);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Del(ProtoEntity entity) => pool.Del(entity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ProtoWorld World() => pool.World();
    }
    
#if ENABLE_IL2CPP
    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
#endif
    public interface IEcsAutoReset<T> : IProtoAutoReset<T> where T : struct { }
}