namespace UniGame.LeoEcs.Shared.Abstract
{
    using Leopotam.EcsProto;

    public interface IInitializeWithEntityData
    {
        public void InitializeEcsData(ProtoWorld world, int entity);
    }
}
