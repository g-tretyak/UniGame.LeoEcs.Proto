namespace Game.Ecs.Core.Converters
{
    using Components;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    public sealed class GroundInfoMonoConverter : MonoLeoEcsConverter
    {
        [SerializeField]
        public float _checkDistance = 0.3f;
        
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            var groundInfoPool = world.GetPool<GroundInfoComponent>();
            
            ref var groundInfo = ref groundInfoPool.Add(entity);
            groundInfo.CheckDistance = _checkDistance;
        }
    }
}