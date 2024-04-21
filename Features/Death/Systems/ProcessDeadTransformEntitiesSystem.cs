namespace Game.Ecs.Core.Death.Systems
{
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Shared.Extensions;
    using Object = UnityEngine.Object;
    
    public sealed class ProcessDeadTransformEntitiesSystem : IEcsRunSystem,IEcsInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();

            _filter = _world
                .Filter<DestroyComponent>()
                .Inc<TransformComponent>()
                .End();
        }
        
        public void Run()
        {
            var transformPool = _world.GetPool<TransformComponent>();
            
            foreach (var entity in _filter)
            {
                ref var transformComponent = ref transformPool.Get(entity);
                var transform = transformComponent.Value;
                
                if(transform && transform.gameObject)
                    Object.Destroy(transform.gameObject);
                
                _world.DelEntity(entity);
            }
        }
    }
}