namespace UniGame.LeoEcs.ViewSystem.Systems
{
    using System;
    using Aspects;
    using Bootstrap.Runtime.Attributes;
    using Components;
    using Converter.Runtime.Components;
    using Leopotam.EcsLite;
    using Shared.Components;
    using UnityEngine;
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class UpdateViewOrderSystem : IProtoInitSystem,IProtoRunSystem
    {
        private ViewAspect _viewAspect;
        private EcsFilter _viewFilter;
        private ProtoWorld _world;
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _viewFilter = _world
                .Filter<ViewComponent>()
                .Inc<TransformComponent>()
                .Inc<ViewOrderComponent>()
                .End();
        }

        public void Run()
        {
            foreach (var entity in _viewFilter)
            {
                ref var orderComponent = ref _viewAspect.Order.Get(entity);
                ref var transformComponent = ref _viewAspect.Transform.Get(entity);

                var transform = transformComponent.Value;
                var order = transform.GetSiblingIndex();
                orderComponent.Value = order;
            }
        }
    }
}