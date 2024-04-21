using System;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Ecs.Core.Components
{
    using Leopotam.EcsProto.QoL;

    [Serializable]
    public struct CharacterLinkComponent
    {
        public ProtoPackedEntity CharacterEntity;
    }
}
