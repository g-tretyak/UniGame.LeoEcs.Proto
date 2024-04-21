namespace Game.Ecs.Core.Death.Converters
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
    public class PoolingComponentConverter : GameObjectConverter
    {
        protected override void OnApply(GameObject target,ProtoWorld world, int entity)
        {
            world.GetOrAddComponent<PoolingComponent>(entity);
        }
    }
}