namespace Game.Ecs.Time.Converters
{
    using System;
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public class GameTimeConverter : LeoEcsConverter
    {
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            var gameTimePool = world.GetPool<EntityGameTimeComponent>();
            gameTimePool.Add(entity);
        }
    }
}