namespace UniGame.LeoEcs.Debug.Editor
{
    using System;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniModules.UniCore.Runtime.Utils;

    [Serializable]
    public class IdEntitiesFilter : IProtoWorldSearchFilter
    {
        public Slice<int> entities = new();

        public EcsFilterData Execute(EcsFilterData filterData)
        {
            var world = filterData.world;
            entities.Clear();

            world.GetAliveEntities(entities);
            var isEmptyFilter = string.IsNullOrEmpty(filterData.filter);

            var len = entities.Len();
            var data = entities.Data();

            for (var i = 0; i < len; i++)
            {
                var entity = data[i];
                var idValue = entity.ToStringFromCache();
                var isValid = isEmptyFilter || 
                              idValue.Contains(filterData.filter, StringComparison.OrdinalIgnoreCase);
                
                if(!isValid) continue;
                
                filterData.entities.Add(entity);
            }

            return filterData;
        }

    }
}