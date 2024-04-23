using Leopotam.EcsLite;
using UniGame.Core.Runtime;
using UniModules.UniCore.Runtime.DataFlow;

namespace UniGame.LeoEcs.Shared.Systems
{
    using Leopotam.EcsProto;

    public class LifeTimeEcsSystem : IProtoInitSystem,IEcsDestroySystem,ILifeTimeContext
    {
        private LifeTimeDefinition _lifeTime = new LifeTimeDefinition();

        public ILifeTime LifeTime => _lifeTime;
        
        public void Init(IProtoSystems systems)
        {
            _lifeTime.Release();
            OnInit(systems,_lifeTime);
        }

        public void Destroy()
        {
            OnDestroy();
            _lifeTime.Release();
        }

        protected virtual void OnInit(IProtoSystems systems, ILifeTime lifeTime)
        {
            
        }
        
        protected virtual void OnDestroy()
        {
            
        }
    }
}
