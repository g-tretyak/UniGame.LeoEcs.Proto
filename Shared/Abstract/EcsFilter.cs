namespace Leopotam.EcsLite
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using EcsProto;
    using UnityEngine.Pool;
    
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
    
    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
#endif
    public class EcsFilter : IProtoIt
    {
        public IProtoIt it;
        public ProtoWorld world;

        public List<Type> includeTypes;
        public List<Type> excludeTypes;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter Filter<TComponent>(ProtoWorld protoWorld) where TComponent : struct
        {
            world = protoWorld;
            includeTypes ??= ListPool<Type>.Get();
            excludeTypes ??= ListPool<Type>.Get();

            includeTypes.Add(typeof(TComponent));
            return this;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter Inc<TComponent>() where TComponent : struct
        {
            includeTypes.Add(typeof(TComponent));
            return this;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter Exc<TComponent>()
            where TComponent : struct
        {
            excludeTypes.Add(typeof(TComponent));
            return this;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public EcsFilter EndFilter()
        {
            var includeComponents = includeTypes.ToArray();
            var excludeComponents = excludeTypes.ToArray();
            var useExclude = excludeTypes.Count > 0;
            it = useExclude 
                ? new ProtoItExc(includeComponents, excludeComponents) 
                : new ProtoIt(includeComponents);

            Init(world);
                
            includeTypes.Clear();
            excludeTypes.Clear();
            
            ListPool<Type>.Release(includeTypes);
            ListPool<Type>.Release(excludeTypes);

            includeTypes = null;
            excludeTypes = null;
            
            return this;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IProtoIt Init(ProtoWorld protoWorld)
        {
            world = protoWorld;
            return it.Init(protoWorld);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ProtoWorld World()
        {
            return world;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Has(ProtoEntity entity)
        {
            return it.Has(entity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Begin()
        {
            it.Begin();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Next()
        {
            return it.Next();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void IProtoIt.End()
        {
            it.End();
        }

        public ProtoEntity Entity()
        {
            return it.Entity();
        }
        
    }
}