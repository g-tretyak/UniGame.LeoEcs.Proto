namespace UniGame.LeoEcs.Debug.Editor
{
    public interface IProtoWorldSearchFilter
    {
        public EcsFilterData Execute(EcsFilterData filterData);
    }
}