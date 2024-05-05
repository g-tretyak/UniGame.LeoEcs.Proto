namespace Game.Ecs.Core.Converters
{
    using System;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public sealed class AnimatorConverter : LeoEcsConverter,IConverterEntityDestroyHandler
    {
        [SerializeField]
        public Animator animator;
        
        public override void Apply(GameObject target, ProtoWorld world, ProtoEntity entity)
        {
            var animatorPool = world.GetPool<AnimatorComponent>();
            ref var animatorComponent = ref animatorPool.GetOrAddComponent(entity);
            animatorComponent.Value = animator;
        }

        public void OnEntityDestroy(ProtoWorld world, ProtoEntity entity)
        {
            world.TryRemoveComponent<AnimatorComponent>(entity);
        }
    }
}