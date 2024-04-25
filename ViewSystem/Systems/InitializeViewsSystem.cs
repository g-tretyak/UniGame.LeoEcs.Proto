namespace UniGame.LeoEcs.ViewSystem.Systems
{
    using System;
    using Behavriour;
    using Components;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Shared.Extensions;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class InitializeViewsSystem : IProtoInitSystem,IProtoRunSystem
    {
        private readonly IEcsViewTools _viewTools;
        
        private ProtoWorld _world;
        private EcsFilter _filter;
        
        private ProtoPool<ViewInitializedComponent> _viewInitializedPool;
        private ProtoPool<ViewComponent> _viewComponentPool;
        private ProtoPool<ViewModelComponent> _viewModelPool;

        public InitializeViewsSystem(IEcsViewTools viewTools)
        {
            _viewTools = viewTools;
        }
        
        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<ViewComponent>()
                .Exc<ViewInitializedComponent>()
                .End();

            _viewInitializedPool = _world.GetPool<ViewInitializedComponent>();
            _viewComponentPool = _world.GetPool<ViewComponent>();
            _viewModelPool = _world.GetPool<ViewModelComponent>();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                _viewInitializedPool.Add(entity);
                
                ref var viewComponent = ref _viewComponentPool.Get(entity);
                var packedEntity = _world.PackEntity(entity);
                var view = viewComponent.View;
                var viewType = viewComponent.Type;
                ref var viewModelComponent = ref _viewModelPool.GetOrAddComponent(entity);
                
                if (view.IsModelAttached)
                {
                    viewModelComponent.Model = view.ViewModel;
                    continue;
                }
                
                _viewTools.AddModelComponentAsync(_world, packedEntity, view, viewType)
                    .AttachExternalCancellation(_viewTools.LifeTime.Token)
                    .Forget();
            }
        }

    }
}