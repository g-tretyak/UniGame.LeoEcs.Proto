namespace UniGame.LeoEcs.Converter.Runtime
{
    using System;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Leopotam.EcsProto.Unity.Editor;
    using Sirenix.OdinInspector;
    using UnityEngine;

    [Serializable]
    public class EntityInfoView
    {
        public bool ShowComponents = false;
        [HideInInspector]
        public ProtoPackedEntity Entity;
        [HideInInspector]
        public ProtoWorld World;

#if UNITY_EDITOR
        
        [OnInspectorGUI]
        public void OnInspector()
        {
            if (!ShowComponents) return;
            if (!World.IsAlive()) return;
            if (!Entity.Unpack(World, out var entity)) return;
            
            var view = new EntityDebugInfo {
                World = World,
                Entity = entity,
            };
            
            ComponentInspectors.RenderEntity (view);
        }
        
#endif
    }
}