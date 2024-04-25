using System;
using Game.Ecs.Core.Components;
using UniGame.LeoEcs.Converter.Runtime;

namespace Game.Ecs.Core.Converters
{
    using Leopotam.EcsProto;
    using UniGame.LeoEcs.Shared.Extensions;

    [Serializable]
    public class SelectionTargetConverter : EcsComponentConverter
    {
        public override void Apply(ProtoWorld world, ProtoEntity entity)
        {
            world.GetOrAddComponent<SelectionTargetComponent>(entity);
        }
    }
}
