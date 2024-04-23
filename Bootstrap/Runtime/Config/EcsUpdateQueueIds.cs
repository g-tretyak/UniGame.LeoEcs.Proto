namespace UniGame.Ecs.Bootstrap.Runtime.Config
{
    using System.Collections.Generic;
#if UNITY_EDITOR
    using UniModules.Editor;
#endif
    
    public static class EcsUpdateQueueIds
    {
        public static IEnumerable<string> GetUpdateIds()
        {
#if UNITY_EDITOR

            var map = AssetEditorTools.GetAsset<EcsUpdateMapAsset>();
            if(map == null) yield break;
            foreach (var updateQueue in map.updateQueue)
            {
                yield return updateQueue.OrderId;
            }
#endif
            yield break;
        }
        
    }
}