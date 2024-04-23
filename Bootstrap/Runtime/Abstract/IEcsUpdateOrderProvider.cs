using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

namespace UniGame.Ecs.Bootstrap.Runtime.Config
{
    public interface IEcsUpdateOrderProvider
    {
        IEcsExecutor Create();
    }
}