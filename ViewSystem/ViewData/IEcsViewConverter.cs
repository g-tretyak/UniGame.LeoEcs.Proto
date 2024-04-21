namespace UniGame.LeoEcs.ViewSystem.Converters
{
    using Converter.Runtime;
    using Core.Runtime;
    using Leopotam.EcsLite;

    public interface IEcsViewConverter :
        IConverterEntityDestroyHandler
    {
        bool IsEnabled { get; }
        ProtoWorld World { get; }
        ProtoPackedEntity PackedEntity { get; }
        int Entity { get; }
    }
}