namespace Game.Ecs.TargetSelection
{
    using System;
    using Leopotam.EcsProto;

    [Serializable]
    public readonly struct EntityFloat
    {
        public readonly ProtoEntity entity;
        public readonly float value;

        public EntityFloat(ProtoEntity entity,float value)
        {
            this.entity = entity;
            this.value = value;
        }
    }
}