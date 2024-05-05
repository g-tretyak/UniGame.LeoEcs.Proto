namespace UniGame.LeoEcs.ViewSystem.Aspects
{
    using System;
    using Components;
    using Converter.Runtime.Components;
    using Bootstrap.Runtime.Abstract;
    using Game.Modules.UnioModules.UniGame.LeoEcsLite.LeoEcs.ViewSystem.Components.Events;
    using Leopotam.EcsProto;
    using Shared.Components;

    [Serializable]
    public class ViewAspect : EcsAspect
    {
        public ProtoPool<ViewComponent> View;
        public ProtoPool<ViewModelComponent> Model;
        public ProtoPool<ViewEntityLifeTimeComponent> LifeTime;
        
        public ProtoPool<ViewStatusComponent> Status;
        public ProtoPool<ViewOrderComponent> Order;
        
        public ProtoPool<TransformComponent> Transform;
        
        //events
        public ProtoPool<ViewStatusSelfEvent> StatusChanged;
        
        //requests
        public ProtoPool<CreateLayoutViewRequest> CreateLayoutView;
        public ProtoPool<CloseViewSelfRequest> CloseView;
    }
}