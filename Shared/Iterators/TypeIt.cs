namespace UniGame.LeoEcs.ViewSystem.Data
{
    using System;
    using System.Runtime.CompilerServices;
    using Leopotam.EcsProto;
    using Proto.Components;
    using Shared.Extensions;
    using UniModules.UniCore.Runtime.Utils;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
#endif
    [Serializable]
    public struct TypeIt : IProtoIt
    {
        public IProtoIt it;
        public uint id;
        public ProtoWorld world;
        public ProtoPool<TypeIdComponent> pool;

        public TypeIt(IProtoIt protoIt,Type target)
        {
            it = protoIt;
            id = target.GetTypeId();
            world = protoIt.World();
            pool = world.GetPool<TypeIdComponent>();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IProtoIt Init(ProtoWorld protoWorld)
        {
            return it.Init(protoWorld);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ProtoWorld World()
        {
            return it.World();
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
            var isNext = true;

            while (isNext)
            {
                isNext = it.Next();
                if(!isNext) return false;
            
                var entity = it.Entity();
                if (!pool.Has(entity)) continue;
                
                ref var viewComponent = ref pool.Get(entity);
                if (viewComponent.Value == id) return true;
            }
            
            return false;
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