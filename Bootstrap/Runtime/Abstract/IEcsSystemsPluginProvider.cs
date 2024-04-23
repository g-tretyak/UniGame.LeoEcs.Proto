namespace UniGame.Ecs.Bootstrap.Runtime.Config
{
    using LeoEcs.Bootstrap.Runtime.Abstract;

    public interface IEcsSystemsPluginProvider
    {
        ISystemsPlugin Create();
    }
}