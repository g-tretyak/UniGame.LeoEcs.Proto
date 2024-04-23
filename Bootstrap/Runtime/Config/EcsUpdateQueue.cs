using System;
using UnityEngine;

namespace UniGame.Ecs.Bootstrap.Runtime.Config
{
    [Serializable]
    public class EcsUpdateQueue
    {
        public string OrderId = string.Empty;
        
        [SerializeReference]
        public IEcsUpdateOrderProvider Factory;
    }
}