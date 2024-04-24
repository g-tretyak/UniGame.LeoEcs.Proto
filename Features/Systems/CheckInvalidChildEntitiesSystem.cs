namespace Game.Ecs.Core.Systems
{
    using System;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class CheckInvalidChildEntitiesSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        
        private ProtoPool<OwnerComponent> _ownerPool;
        private ProtoPool<OwnerDestroyedEvent> _ownerDestroyedPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<OwnerComponent>().End();
        }
        
        public void Run()
        {
            
            foreach (var entity in _filter)
            {
                ref var ownerComponent = ref _ownerPool.Get(entity);
                if(ownerComponent.Value.Unpack(_world, out _))
                    continue;

                _ownerDestroyedPool.Add(entity);
            }
        }
    }
}