namespace UniGame.LeoEcs.Bootstrap.Runtime.Abstract
{
    public interface IEcsExecutorFactory
    {
        IEcsExecutor Create(string updateId);
    }
}