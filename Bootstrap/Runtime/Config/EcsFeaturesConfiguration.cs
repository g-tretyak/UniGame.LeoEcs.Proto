namespace UniGame.Ecs.Bootstrap.Runtime.Config
{
    using System.Collections.Generic;
    using LeoEcs.Bootstrap.Runtime.Abstract;
    using UnityEngine;

#if ODIN_INSPECTOR
    using Sirenix.OdinInspector;
#endif

#if TRI_INSPECTOR
    using TriInspector;
#endif
    
    [CreateAssetMenu(menuName = "UniGame/Ecs Proto/ECS Features Configuration", fileName = nameof(EcsFeaturesConfiguration))]
    public class EcsFeaturesConfiguration : ScriptableObject, IEcsSystemsConfig
    {
#if ODIN_INSPECTOR
       [FoldoutGroup("world config")]
#endif
#if ODIN_INSPECTOR || TRI_INSPECTOR
        [InlineProperty]
        [HideLabel]
#endif
        public WorldConfiguration worldConfiguration = new WorldConfiguration();
        
        [Space(8)]
        [SerializeField]
#if ODIN_INSPECTOR
        [ListDrawerSettings(ListElementLabelName = "updateType")]
#endif
        //[Searchable(FilterOptions = SearchFilterOptions.ISearchFilterableInterface)]
        public List<EcsConfigGroup> ecsUpdateGroups = new List<EcsConfigGroup>();
        
        public IReadOnlyList<EcsConfigGroup> FeatureGroups => ecsUpdateGroups;
    }
}