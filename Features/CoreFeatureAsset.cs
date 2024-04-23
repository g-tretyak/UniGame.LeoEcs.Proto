namespace Game.Ecs.Core
{
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Proto Feature/Core/Core Feature", fileName = "Core Feature")]
    public class CoreFeatureAsset : BaseLeoEcsFeature
    {
        public CoreFeature coreFeature = new();
        
        public override async UniTask InitializeFeatureAsync(IProtoSystems ecsSystems)
        {
            await coreFeature.InitializeFeatureAsync(ecsSystems);
        }
    }
    
}