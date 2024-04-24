namespace UniGame.LeoEcs.Shared.Components
{
    using System;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Extensions;

    /// <summary>
    /// update render components
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class UpdateRenderStatusSystem : IProtoInitSystem, IProtoRunSystem
    {
        private ProtoWorld _world;
        private EcsFilter _filter;
        private ProtoPool<RendererComponent> _renderPool;
        private ProtoPool<RendererEnabledComponent> _renderEnabledPool;
        private ProtoPool<RendererVisibleComponent> _renderVisiblePool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<RendererComponent>().End();

            _renderPool = _world.GetPool<RendererComponent>();
            _renderEnabledPool = _world.GetPool<RendererEnabledComponent>();
            _renderVisiblePool = _world.GetPool<RendererVisibleComponent>();
        }

        public void Run()
        {
            foreach (var entity in _filter)
            {
                ref var renderComponent = ref _renderPool.Get(entity);

                var render = renderComponent.Value;
                if (render.enabled)
                {
                    _renderEnabledPool.GetOrAddComponent(entity);
                }
                else
                {
                    _renderEnabledPool.TryRemove(entity);
                }
                
                if (render.isVisible)
                {
                    _renderVisiblePool.GetOrAddComponent(entity);
                }
                else
                {
                    _renderVisiblePool.TryRemove(entity);
                }
            }
        }
    }
}