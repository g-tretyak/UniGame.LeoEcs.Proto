namespace Game.Ecs.Core.Converters
{
    using System;
    using Components;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    public sealed class IconConverter : MonoLeoEcsConverter
    {
        [SerializeField]
        public AssetReferenceT<Sprite> _icon;
        
        public override void Apply(GameObject target, ProtoWorld world, int entity)
        {
            ref var icon = ref world.AddComponent<IconComponent>(entity);
            icon.Value = _icon;
        }
    }

    [Serializable]
    public class IconComponentConverter : LeoEcsConverter
    {
        [SerializeField]
        public AssetReferenceT<Sprite> icon;
        
        public override void Apply(GameObject source,ProtoWorld world, int entity)
        {
            Convert(source,world,entity).Forget();
        }

        private UniTask Convert(GameObject source,ProtoWorld world, int entity)
        {
            CreateComponent(icon, world, entity);
            return UniTask.CompletedTask;
        }

        private void CreateComponent(AssetReferenceT<Sprite> sprite,ProtoWorld world, int entity)
        {
            ref var iconComponent = ref world.AddComponent<IconComponent>(entity);
            iconComponent.Value = sprite;
        }
    }
}