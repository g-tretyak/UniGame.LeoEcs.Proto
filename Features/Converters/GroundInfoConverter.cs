namespace Game.Ecs.Core.Converters
{
    using System;
    using System.Threading;
    using Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public sealed class GroundInfoConverter : LeoEcsConverter
    {
        [SerializeField]
        public float _checkDistance = 0.3f;
        
        public override void Apply(GameObject target, ProtoWorld world, int entity)
        {
            var groundInfoPool = world.GetPool<GroundInfoComponent>();
            
            ref var groundInfo = ref groundInfoPool.Add(entity);
            groundInfo.CheckDistance = _checkDistance;
        }
    }
}