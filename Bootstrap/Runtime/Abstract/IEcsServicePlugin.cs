namespace UniGame.LeoEcs.Bootstrap.Runtime.Abstract
{
    using Core.Runtime;

    public interface IEcsServicePlugin
    {
        void Init(EcsFeatureSystems ecsSystems);
        void PreInit(IContext context);
        void PostInit();
    }
}