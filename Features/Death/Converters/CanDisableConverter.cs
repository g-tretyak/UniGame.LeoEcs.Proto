namespace Game.Ecs.Core.Death.Converters
{
    using System;
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public sealed class CanDisableConverter : LeoEcsConverter
    {
        [SerializeField] 
        public bool addDisabledOnAwake = true;
        
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            world.AddComponent<CanDisableComponent>(entity);

            if (addDisabledOnAwake)
                world.AddComponent<DisabledComponent>(entity);
        }
    }
}