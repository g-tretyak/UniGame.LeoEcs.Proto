namespace UniGame.Ecs.Bootstrap.Runtime.Config
{
    using Cysharp.Threading.Tasks;
    using System.Collections.Generic;
    using System.Diagnostics;
    using LeoEcs.Bootstrap.Runtime;
    using LeoEcs.Bootstrap.Runtime.Abstract;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniCore.Runtime.ProfilerTools;
    using UnityEngine;

#if ODIN_INSPECTOR
    using Sirenix.OdinInspector;
#endif

#if TRI_INSPECTOR
    using TriInspector;
#endif
    
    [CreateAssetMenu(menuName = "UniGame/Ecs Proto/ECS Feature Group", fileName = "ECS Feature Group")]
    public class EcsFeatureGroupAsset : 
        BaseLeoEcsFeature, 
        IEcsSystemsGroup
    {
        #region inspector
        
#if ODIN_INSPECTOR || TRI_INSPECTOR
        [InlineProperty]
        [HideLabel]
#endif
        public EcsSystemsGroupConfiguration groupConfiguration = new EcsSystemsGroupConfiguration();

        #endregion

        #region public properties

        public IReadOnlyList<IEcsSystem> EcsSystems => groupConfiguration.EcsSystems;
        
        public void RegisterSystems(List<IEcsSystem> systems)
        {
            systems.AddRange(EcsSystems);
        }

        public override string FeatureName => string.IsNullOrEmpty(groupConfiguration.FeatureName)
            ? name
            : groupConfiguration.FeatureName;
        
        public override bool IsFeatureEnabled => groupConfiguration.IsFeatureEnabled;

        public override bool ShowFeatureInfo => false;


        #endregion
        
        public sealed override async UniTask InitializeFeatureAsync(IProtoSystems ecsSystems)
        {
#if DEBUG
            var timer = Stopwatch.StartNew();   
            timer.Restart();
#endif
            await OnInitializeFeatureAsync(ecsSystems);
#if DEBUG
            var elapsed = timer.ElapsedMilliseconds;
            timer.Stop();
            GameLog.LogRuntime($"\tECS FEATURE SOURCE: SELF LOAD TIME {FeatureName} | {GetType().Name} = {elapsed} ms");
#endif
            await groupConfiguration.InitializeFeatureAsync(ecsSystems);
            await OnPostInitializeFeatureAsync(ecsSystems);
            
#if DEBUG
            GameLog.LogRuntime($"\n");
#endif
        }

        public override bool IsMatch(string searchString)
        {
            if (base.IsMatch(searchString)) return true;

            return groupConfiguration != null && 
                   groupConfiguration.IsMatch(searchString);
        }
        
        protected virtual UniTask OnInitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            return UniTask.CompletedTask;
        }
        
        protected virtual UniTask OnPostInitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            return UniTask.CompletedTask;
        }

#if ODIN_INSPECTOR
        [OnInspectorInit]
#endif
        private void OnInspectorInitialize()
        {
            if (groupConfiguration != null && 
                string.IsNullOrEmpty(groupConfiguration.FeatureName))
                groupConfiguration.name = name;
        }
    }
}