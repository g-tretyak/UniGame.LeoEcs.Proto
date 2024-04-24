namespace UniGame.LeoEcs.ViewSystem.Layouts.Aspects
{
    using Components;
    using Game.Modules.UnioModules.UniGame.LeoEcsLite.LeoEcs.ViewSystem.Components;
    using Bootstrap.Runtime.Abstract;
    using Leopotam.EcsLite;

    public class ViewLayoutAspect : EcsAspect
    {
        public ProtoPool<ViewLayoutComponent> Layout;
        public ProtoPool<ViewParentComponent> Parent;
        
        //operations
        public ProtoPool<RegisterViewLayoutSelfRequest> Register;
        public ProtoPool<RemoveViewLayoutSelfRequest> Remove;
    }
}