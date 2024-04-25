using Leopotam.EcsLite;

namespace UniGame.LeoEcs.Converter.Runtime
{
    using Leopotam.EcsProto;

    public interface IConverterEntityDestroyHandler
    {

        void OnEntityDestroy(ProtoWorld world, ProtoEntity entity);

    }
}