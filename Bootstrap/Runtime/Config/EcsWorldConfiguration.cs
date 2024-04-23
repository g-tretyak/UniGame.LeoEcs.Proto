namespace UniGame.Ecs.Bootstrap.Runtime.Config
{
    using System;
    using Leopotam.EcsProto;

    [Serializable]
    public class WorldConfiguration
    {
        public int Entities = 256;
        public int RecycledEntities = 256;
        public int Pools = 256;
        public int Aspects = 4;

        public ProtoWorld.Config Create()
        {
            var config = new ProtoWorld.Config()
            {
                Entities = Entities,
                RecycledEntities = RecycledEntities,
                Pools = Pools,
                Aspects = Aspects,
            };

            return config;
        }
    }
}