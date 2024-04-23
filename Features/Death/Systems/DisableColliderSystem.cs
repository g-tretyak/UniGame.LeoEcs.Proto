namespace Game.Ecs.Core.Death.Systems
{
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Shared.Extensions;

    public sealed class DisableColliderSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        private EcsPool<ColliderComponent> _colliderPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<ColliderComponent>()
                .Inc<DisabledEvent>()
                .End();
            
            _colliderPool = _world.GetPool<ColliderComponent>();
        }
        
        public void Run()
        {
            

            foreach (var entity in _filter)
            {
                ref var collider = ref _colliderPool.Get(entity);
                collider.Value.enabled = false;
            }
        }
    }
}