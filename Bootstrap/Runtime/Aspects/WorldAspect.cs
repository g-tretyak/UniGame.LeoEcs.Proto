namespace UniGame.LeoEcs.Bootstrap.Runtime.Aspects
{
    using System;
    using System.Collections.Generic;
    using Leopotam.EcsProto;

    [Serializable]
    public class WorldAspect : IProtoAspect
    {
        public Dictionary<Type,IProtoAspect> aspects = new();
        
        public IEnumerable<IProtoAspect> Aspects => aspects.Values;
        
        public void AddAspect(IProtoAspect aspect)
        {
            var type = aspect.GetType();
            aspects[type] = aspect;
        }
        
        public void Init(ProtoWorld world)
        {
            foreach (var aspect in aspects)
            {
                aspect.Value.Init(world);
            }
        }

        public void PostInit()
        {
            foreach (var aspect in aspects)
            {
                aspect.Value.PostInit();
            }
        }
    }
}