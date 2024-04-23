namespace UniGame.LeoEcs.Bootstrap.Runtime.Abstract
{
    using Core.Runtime;
    using Leopotam.EcsProto;

    public interface IEcsPostInitializeAction
    {
        public (IProtoSystems value, bool replace) Apply(IProtoSystems ecsSystems,IContext context);
    }
}