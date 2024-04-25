namespace UniGame.LeoEcs.ViewSystem.Behavriour
{
    using System;
    using Converters;
    using Core.Runtime.SerializableType;
    using Core.Runtime.SerializableType.Attributes;
    using Extensions;
    using Leopotam.EcsProto;
    using Sirenix.OdinInspector;
    using UniModules.UniGame.UiSystem.Runtime;
    using UnityEngine;

    [Serializable]
    public class ViewRequestTrigger
    {
        #region inspector

#if ODIN_INSPECTOR
        [DrawWithUnity]
#endif
        [STypeFilter(typeof(IEcsView))]
        public SType view;
        
        public ViewType layoutType = ViewType.Window;
        
        #endregion

        public void Show(ProtoWorld world, Transform parent = null)
        {
            world.MakeViewRequest(view, layoutType, parent);
        }
        
    }
}