namespace UniGame.LeoEcs.Bootstrap.Runtime.PostInitialize
{
    using System;
    using Abstract;
    using Core.Runtime;

    [Serializable]
    public class EcsProfilePlugin : IEcsServicePlugin
    {
        public void Init(EcsFeatureSystems ecsSystems)
        {
#if ENABLE_ECS_DEBUG
            var profileSystems = new List<EcsProfileSystem>();
            var systems = ecsSystems.GetAllSystems();
            
            foreach (var ecsSystem in systems)
            {
                var ecsProfileSystem = new EcsProfileSystem();
                ecsProfileSystem.Initialize(ecsSystem);
                profileSystems.Add(ecsProfileSystem);
            }
            
            systems.Clear();
            systems.AddRange(profileSystems);
#endif
        }
        
        public void PreInit(IContext context)
        {
        }

        public void PostInit()
        {
        }
    }
}