namespace UniGame.LeoEcs.Bootstrap.Runtime.Abstract
{
    using System;
    using Game.Ecs.Core.Components;
    using LeoEcsLite.LeoEcs.Shared.Components;
    using Leopotam.EcsProto;
    using Shared.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    /// <summary>
    /// lifetime management proto aspect
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class LifeTimeAspect : EcsAspect
    {
        public ProtoPool<KillMeNextTimeComponent> KillMeNextTime;
        public ProtoPool<LifeTimeComponent> LifeTime;
        public ProtoPool<OwnerComponent> Owner;
        public ProtoPool<OwnerLinkComponent> OwnerLink;
        public ProtoPool<PrepareToDeathComponent> PrepareToDeath;
        
        //events
        public ProtoPool<PrepareToDeathEvent> PrepareToDeathEvent;
        public ProtoPool<OwnerDestroyedEvent> OwnerDestroyedEvent;
    }
}