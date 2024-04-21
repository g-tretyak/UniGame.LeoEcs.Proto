namespace UniGame.LeoEcs.Converter.Runtime
{
    using Core.Runtime;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto.QoL;

    public interface IEcsEntity
    {
        public int Entity { get; }
        
        public ProtoPackedEntity PackedEntity { get; }
        
        public ILifeTime LifeTime { get; }
    }
}