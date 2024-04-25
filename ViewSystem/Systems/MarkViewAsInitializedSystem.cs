namespace UniGame.LeoEcs.ViewSystem.Systems
{
    using System;
    using Bootstrap.Runtime.Attributes;
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
    [ECSDI]
    public class MarkViewAsInitializedSystem : IProtoRunSystem,IProtoInitSystem
    {
        private EcsFilter _filter;
        private ProtoWorld _world;
        private ProtoPool<ViewInitializedComponent> _viewInitialized;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<ViewComponent>()
                .Inc<ViewModelComponent>()
                .Exc<ViewInitializedComponent>()
                .End();
            
            _viewInitialized = _world.GetPool<ViewInitializedComponent>();
        }
        
        public void Run()
        {
            foreach (var viewEntity in _filter)
            {
                _world.GetOrAddComponent<ViewInitializedComponent>(viewEntity);
            }
        }

    }
}