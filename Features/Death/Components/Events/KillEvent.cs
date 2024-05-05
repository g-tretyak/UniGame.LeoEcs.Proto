namespace Game.Ecs.Core.Death.Components
{
    using Leopotam.EcsProto.QoL;

    /// <summary>
    /// separate entity event with source and dest targets
    /// </summary>
    public struct KillEvent
    {
        public ProtoPackedEntity Source;
        public ProtoPackedEntity Destination;
    }
}