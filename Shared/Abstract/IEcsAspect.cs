namespace UniGame.LeoEcs.Bootstrap.Runtime
{
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;

    public interface IEcsAspect : IProtoAspect 
    {
        public void Initialize(EcsWorld world);
    }
}