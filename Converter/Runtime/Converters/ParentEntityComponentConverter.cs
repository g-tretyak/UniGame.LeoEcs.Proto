namespace UniGame.LeoEcs.Converter.Runtime.Converters
{
    using System;
    using System.Threading;
    using Runtime;
    using global::UniGame.LeoEcs.Shared.Extensions;
    using global::UniGame.LeoEcsLite.LeoEcs.Shared.Components;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UnityEngine;

    [Serializable]
    public class ParentEntityComponentConverter : LeoEcsConverter
    {
        public sealed override void Apply(GameObject target, ProtoWorld world, int entity)
        {
            var parentEntity = target.GetParentEntity();
            if(parentEntity<0) return;
            
            ref var parentEntityComponent = ref world.GetOrAddComponent<ParentEntityComponent>(entity);
            parentEntityComponent.Value = world.PackedEntity(parentEntity);
        }
    }
}