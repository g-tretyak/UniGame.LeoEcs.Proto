namespace UniGame.LeoEcs.Debug.Editor
{
    using System;
    using System.Collections.Generic;
    using Leopotam.EcsProto;

    [Serializable]
    public class EcsEditorFilter
    {
        private HashSet<int> _uniqueEntities = new HashSet<int>();

        private List<IProtoWorldSearchFilter> _ecsResultFilter = new List<IProtoWorldSearchFilter>()
        {
            new CheckEditorStatusFilter(),
            new CheckProtoWorldStatusFilter(),
            new IdEntitiesFilter(),
            new EntitiesNamesFilter(),
            new FilterEntitiesComponents(),
        };

        public EcsFilterData Filter(string filterValue,ProtoWorld world)
        {
            var filterData = new EcsFilterData
            {
                world = world,
                filter = filterValue,
                message = string.Empty,
                type = ResultType.Success
            };

            var filter = filterData;

            foreach (var searchFilter in _ecsResultFilter)
            {
                filter = searchFilter.Execute(filter);

                if (filter.type == ResultType.Error)
                    break;
            }
            
            return filter;
        }

    }
}