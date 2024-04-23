namespace Game.Ecs.Time.Systems
{
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Service;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    public class UpdateEntityTimeSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<EntityGameTimeComponent>().End();
        }
        
        public void Run()
        {
            var gameTimePool = _world.GetPool<EntityGameTimeComponent>();

            GameTime.Time = Time.time;
            GameTime.DeltaTime = Time.deltaTime;
            GameTime.RealTime = Time.realtimeSinceStartup;
            
            foreach (var entity in _filter)
            {
                ref var timeComponent = ref gameTimePool.Get(entity);
                timeComponent.Value += GameTime.DeltaTime;
            }
        }
    }
}
