namespace UniGame.LeoEcs.ViewSystem.Systems
{
    using System;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Shared.Extensions;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class InitializeModelOfViewsSystem : IProtoInitSystem,IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _filter;
        
        private ProtoPool<ViewComponent> _viewComponentPool;
        private ProtoPool<ViewInitializedComponent> _initializedPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<ViewComponent>()
                .Exc<ViewInitializedComponent>()
                .End();

            _viewComponentPool = _world.GetPool<ViewComponent>();
            _initializedPool = _world.GetPool<ViewInitializedComponent>();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var viewComponent = ref _viewComponentPool.Get(entity);
                var view = viewComponent.View;

                if(view.ViewModel == null) continue;

                ref var viewModelComponent = ref _world.GetOrAddComponent<ViewModelComponent>(entity);
                viewModelComponent.Model = view.ViewModel;

                _initializedPool.GetOrAddComponent(entity);
            }
        }

    }
}