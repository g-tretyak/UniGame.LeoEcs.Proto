namespace UniGame.LeoEcs.Bootstrap.Runtime
{
    using System;
    using System.Collections.Generic;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public class EcsSystemsFeature : LeoEcsFeatureAsset
    {

#if ODIN_INSPECTOR
        [Sirenix.OdinInspector.InlineProperty]
#endif
        [SerializeReference]
        private List<IEcsSystem> _systems = new List<IEcsSystem>();

        public IReadOnlyList<IEcsSystem> Systems => _systems;

        protected override UniTask OnInitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            foreach (var ecsSystem in _systems)
                ecsSystems.Add(ecsSystem);
            return UniTask.CompletedTask;
        }
    }
}