namespace UniGame.LeoEcs.ViewSystem.Converters
{
    using Converter.Runtime;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;

    public interface IEcsViewConverter :
        IConverterEntityDestroyHandler
    {
        bool IsEnabled { get; }
        ProtoWorld World { get; }
        ProtoPackedEntity PackedEntity { get; }
        ProtoEntity Entity { get; }
    }
}