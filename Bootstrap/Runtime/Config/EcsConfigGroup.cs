
namespace UniGame.Ecs.Bootstrap.Runtime.Config
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

#if ODIN_INSPECTOR
    using Sirenix.OdinInspector;
#endif

#if TRI_INSPECTOR
    using TriInspector;
#endif
    
    [Serializable]
    public class EcsConfigGroup
#if ODIN_INSPECTOR
    : ISearchFilterable
#endif
    {
#if ODIN_INSPECTOR || TRI_INSPECTOR
        [GUIColor(0.2f,0.9f,0f)]
#endif
#if TRI_INSPECTOR
        [Dropdown(nameof(GetUpdateIds))]
#endif     
#if ODIN_INSPECTOR
        [ValueDropdown(nameof(GetUpdateIds))]
#endif
        public string updateType;

        [Space(8)]
        [SerializeField]
#if ODIN_INSPECTOR || TRI_INSPECTOR
        [InlineProperty]
#endif
#if ODIN_INSPECTOR
        [Searchable(FilterOptions = SearchFilterOptions.ISearchFilterableInterface)]
#endif
        public List<EcsFeatureData> features = new List<EcsFeatureData>();

        public override bool Equals(object obj)
        {
            if (obj is EcsConfigGroup configGroup) return configGroup.updateType == updateType;
            return false;
        }

        public override int GetHashCode() => string.IsNullOrEmpty(updateType) 
            ? 0 
            : updateType.GetHashCode();

        public bool IsMatch(string searchString)
        {
            if (string.IsNullOrEmpty(searchString)) return true;
            foreach (var featureData in features)
            {
                if (featureData.IsMatch(searchString))
                    return true;
            }
            return false;
        }

        public IEnumerable<string> GetUpdateIds()
        {
            return EcsUpdateQueueIds.GetUpdateIds();
        }
        
    }
}