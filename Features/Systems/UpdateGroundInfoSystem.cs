namespace Game.Ecs.Core.Systems
{
    using System;
    using Cysharp.Threading.Tasks;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    public sealed class UpdateGroundInfoSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<GroundInfoComponent>()
                .Inc<TransformComponent>()
                .End();
        }

        public void Run()
        {
            var groundInfoPool = _world.GetPool<GroundInfoComponent>();
            var transformPool = _world.GetPool<TransformComponent>();
            
            foreach (var entity in _filter)
            {
                ref var transformComponent = ref transformPool.Get(entity);
                ref var groundInfo = ref groundInfoPool.Get(entity);

                if (Physics.Raycast(transformComponent.Value.position + Vector3.up * 0.1f, Vector3.down, out var hitInfo, groundInfo.CheckDistance))
                {
                    groundInfo.Normal = hitInfo.normal;
                    groundInfo.IsGrounded = true;
                }
                else
                {
                    groundInfo.Normal = Vector3.up;
                    groundInfo.IsGrounded = false;
                }
            }
        }
    }
}