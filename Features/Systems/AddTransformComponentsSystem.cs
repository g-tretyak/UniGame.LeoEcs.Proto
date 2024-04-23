namespace Game.Ecs.Core.Systems
{
    using System;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Shared.Extensions;
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public sealed class AddTransformComponentsSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;

        private UnityAspect _unityAspect;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<TransformComponent>()
                .Exc<TransformPositionComponent>()
                .Exc<PrepareToDeathComponent>()
                .End();
        }
        
        public void Run()
        {
            foreach (var entity in _filter)
            {
                _unityAspect.Position.GetOrAddComponent(entity);
                _unityAspect.Direction.GetOrAddComponent(entity);
                _unityAspect.Scale.GetOrAddComponent(entity);
                _unityAspect.Rotation.GetOrAddComponent(entity);
            }
        }
    }
}