namespace UniGame.LeoEcs.Bootstrap.Runtime
{
    using System;
    using System.Linq;
    using Abstract;
    using Aspects;
    using Ecs.Bootstrap.Runtime.Config;
    using Converter.Runtime;
    using Core.Runtime;
    using Cysharp.Threading.Tasks;
    using GameFlow.Runtime.Services;
    using Leopotam.EcsProto;
    using UnityEngine;
    using UnityEngine.Serialization;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

#if TRI_INSPECTOR
    using TriInspector;
#endif
    
    [Serializable]
    [CreateAssetMenu(menuName = "UniGame/Ecs Proto/Ecs Service Source", fileName = nameof(EcsServiceSource))]
    public class EcsServiceSource : ServiceDataSourceAsset<IEcsService>,IEcsExecutorFactory
    {
        #region inspector

        /// <summary>
        /// timeout in ms for feature initialization
        /// </summary>
        [Tooltip("timeout in ms for feature initialization")]
        public float featureTimeout = 20000f;
        
#if ODIN_INSPECTOR || TRI_INSPECTOR
        [InlineEditor] 
#endif
        public EcsFeaturesConfiguration features;

#if ODIN_INSPECTOR || TRI_INSPECTOR
        [InlineEditor]
#endif
        [Space(10)]
        [SerializeField]
        public EcsUpdateMapAsset updatesMap;

#if ODIN_INSPECTOR || TRI_INSPECTOR
        [InlineEditor]
        [ShowIf(nameof(IsRuntimeConfigVisible))]
#endif
        [Space(10)]
        [SerializeField]
        public EcsFeaturesConfiguration _runtimeConfiguration;

        #endregion

        private EcsUpdateMapAsset _updateMapData;
        
        public bool IsRuntimeConfigVisible => Application.isPlaying && _runtimeConfiguration != null;

        protected override async UniTask<IEcsService> CreateServiceInternalAsync(IContext context)
        {
            LeoEcsGlobalData.World = null;

            var config = Instantiate(features);
            _updateMapData = Instantiate(updatesMap);
            _runtimeConfiguration = config;

            var plugins = _updateMapData
                .systemsPlugins
                .Select(x => x.Create())
                .ToList();

            var worldConfig = config.worldConfiguration.Create();
            var protoWorld = new ProtoWorld(new WorldDefaultAspect(), worldConfig);
            var world = (ProtoWorld)protoWorld;
            
            context.Publish(world);
            
            var ecsService = new EcsService(context,world, 
                config,
                this, 
                plugins,
                true,featureTimeout);
            
            //start ecs service update
            await ecsService.InitializeAsync();
            ecsService.Execute();
            ecsService.SetDefaultWorld(world);

            var assetName = name;
            
#if UNITY_EDITOR
            LifeTime.LogOnRelease($"SERVICE: LeoEcs Service COMPLETE : {assetName}",Color.yellow);
#endif
            context.LifeTime.AddDispose(ecsService);
            return ecsService;
        }
        
        public IEcsExecutor Create(string updateId)
        {
            foreach (var updateOrder in _updateMapData.updateQueue)
            {
                if (updateOrder.OrderId.Equals(updateId, StringComparison.OrdinalIgnoreCase))
                    return updateOrder.Factory.Create();
            }

            return _updateMapData.defaultFactory?.Create();
        }

    }
}