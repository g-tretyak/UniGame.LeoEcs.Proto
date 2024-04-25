namespace Game.Ecs.TargetSelection
{
    using System;
    using Leopotam.EcsProto;
    using Unity.Mathematics;

    [Serializable]
    public readonly struct EntityVector
    {
        public readonly ProtoEntity entity;
        public readonly float3 point;

        public EntityVector(ProtoEntity entity,float3 distance)
        {
            this.entity = entity;
            this.point = distance;
        }
    }
}