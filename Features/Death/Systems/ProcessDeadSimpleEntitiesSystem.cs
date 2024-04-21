namespace Game.Ecs.Core.Death.Systems
{
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Shared.Extensions;

    public sealed class ProcessDeadSimpleEntitiesSystem : IEcsRunSystem,IEcsInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<DeadEvent>()
                .Exc<TransformComponent>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                _world.DelEntity(entity);
            }
        }
    }
}