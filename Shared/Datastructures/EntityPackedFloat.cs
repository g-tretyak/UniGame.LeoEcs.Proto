namespace Game.Ecs.TargetSelection
{
    using System;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto.QoL;

    [Serializable]
    public readonly struct EntityPackedFloat
    {
        public readonly ProtoPackedEntity entity;
        public readonly float value;

        public EntityPackedFloat(ProtoPackedEntity entity,float distance)
        {
            this.entity = entity;
            this.value = distance;
        }
    }
}