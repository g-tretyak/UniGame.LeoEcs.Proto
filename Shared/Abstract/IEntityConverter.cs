namespace UniGame.LeoEcs.Shared.Abstract
{
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;

    public interface IEntityConverter
    {
        void Apply(ProtoWorld world, ProtoEntity entity);
    }
}