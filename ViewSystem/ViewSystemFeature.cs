namespace UniGame.LeoEcs.ViewSystem
{
    using System;
    using System.Collections.Generic;
    using Behavriour;
    using Bootstrap.Runtime;
    using Cysharp.Threading.Tasks;
    using UniGame.Core.Runtime;
    using Components;
    using Context.Runtime.Extension;
    using Game.Modules.UnioModules.UniGame.LeoEcsLite.LeoEcs.ViewSystem.Components.Events;
    using Layouts.Components;
    using Layouts.Systems;
    using LeoEcsLite.LeoEcs.ViewSystem.Systems;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using Shared.Extensions;
    using Systems;
    using UiSystem.Runtime.Settings;
    using UniGame.ViewSystem.Runtime;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

#if UNITY_EDITOR
    using UnityEditor;
    using UniModules.Editor;
    using UniModules.UniGame.AddressableExtensions.Editor;
#endif
    
    [CreateAssetMenu(menuName = "UniGame/Ecs Proto/Features/Views Feature", fileName = "ECS Views Feature")]
    public class ViewSystemFeature : BaseLeoEcsFeature
    {
        private EcsViewTools _ecsViewTools;
        
        public override async UniTask InitializeAsync(IProtoSystems ecsSystems)
        {
            var context = ecsSystems.GetShared<IContext>();
            var viewSystem = await context.ReceiveFirstAsync<IGameViewSystem>();
            
            _ecsViewTools = new EcsViewTools(context, viewSystem);

            ecsSystems.DelHere<ViewStatusSelfEvent>();
            
            //layouts
            ecsSystems.Add(new RegisterNewViewLayoutSystem(viewSystem));
            ecsSystems.DelHere<RegisterViewLayoutSelfRequest>();
            
            //if view entity is dead and 
            ecsSystems.Add(new CloseViewByDeadEntitySystem());
            ecsSystems.Add(new CloseViewSystem());
            ecsSystems.Add(new ViewServiceInitSystem(viewSystem));
            ecsSystems.Add(new CloseAllViewsSystem(viewSystem));

            //show view queued one by one
            ecsSystems.Add(new ShowViewsQueuedSystem());
            
            //container systems
            ecsSystems.Add(new CreateViewInContainerSystem());
            //check is container free
            ecsSystems.Add(new UpdateViewContainerBusyStatusSystem());

            //view creation systems
            ecsSystems.Add(new CreateLayoutViewSystem());
            ecsSystems.DelHere<CreateLayoutViewRequest>();

            //update view status systems
            ecsSystems.Add(new ViewUpdateStatusSystem());
            ecsSystems.Add(new UpdateViewOrderSystem());
            ecsSystems.Add(new CreateViewSystem(context,viewSystem));
            ecsSystems.Add(new MarkViewAsInitializedSystem());
            
            ecsSystems.Add(new InitializeViewsSystem(_ecsViewTools));
            ecsSystems.Add(new InitializeModelOfViewsSystem());
            //initialize view id component when view initialized
            ecsSystems.Add(new InitializeViewIdComponentSystem());
            ecsSystems.Add(new RemoveUpdateRequest());
            
            ecsSystems.DelHere<CreateViewRequest>();
            ecsSystems.DelHere<CloseAllViewsRequest>();
            ecsSystems.DelHere<CloseViewByTypeRequest>();
            ecsSystems.DelHere<CloseTargetViewByTypeRequest>();
            ecsSystems.DelHere<CloseViewSelfRequest>();
            ecsSystems.DelHere<UpdateViewRequest>();
        }
    }

    [Serializable]
    public class ViewSettingsReference : AssetReferenceT<ViewsSettings>
    {
        public ViewSettingsReference(string guid) : base(guid)
        {
        }
    }
}
