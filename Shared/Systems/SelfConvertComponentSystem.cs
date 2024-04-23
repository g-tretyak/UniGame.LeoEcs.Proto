namespace UniGame.Ecs.Shared
{
    using System;
    using global::UniGame.LeoEcs.Shared.Extensions;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;

    /// <summary>
    /// create target component on entity by triggered component
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class SelfConvertComponentSystem<TTrigger,TTarget> : IProtoInitSystem, IProtoRunSystem
        where TTrigger : struct
        where TTarget : struct
    {
        private ProtoWorld _world;
        private EcsFilter _filter;
        private EcsPool<TTarget> _targetPool;

        public void Init(IProtoSystems systems)
        {
            _world = systems.GetWorld();

            _filter = _world
                .Filter<TTrigger>()
                .Exc<TTarget>()
                .End();

            _targetPool = _world.GetPool<TTarget>();
        }

        public void Run()
        {
            foreach (var entity in _filter)
                _targetPool.Add(entity);
        }
    }
}