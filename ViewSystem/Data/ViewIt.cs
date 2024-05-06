namespace UniGame.LeoEcs.ViewSystem.Data
{
    using System;
    using System.Runtime.CompilerServices;
    using Components;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Shared.Extensions;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
#endif
    [Serializable]
    public struct ViewIt : IProtoIt
    {
        public IProtoIt it;
        public Type type;
        public ProtoWorld world;
        public ProtoPool<ViewComponent> viewComponentPool;

        public ViewIt(IProtoIt protoIt,Type target)
        {
            it = protoIt;
            type = target;
            world = protoIt.World();
            viewComponentPool = world.GetPool<ViewComponent>();
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
                if (!viewComponentPool.Has(entity)) continue;
                
                ref var viewComponent = ref viewComponentPool.Get(entity);
                if (viewComponent.Type == type)
                    return true;
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