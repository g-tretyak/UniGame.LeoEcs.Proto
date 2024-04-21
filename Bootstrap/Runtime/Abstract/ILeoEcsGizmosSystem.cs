namespace UniGame.LeoEcs.Bootstrap.Runtime.Abstract
{
    using Leopotam.EcsProto;

    public interface ILeoEcsGizmosSystem
    {
        void RunGizmosSystem(IProtoSystems systems);
    }
}