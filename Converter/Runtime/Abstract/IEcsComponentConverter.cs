namespace UniGame.LeoEcs.Converter.Runtime.Abstract
{
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;

#if ODIN_INSPECTOR
    using Sirenix.OdinInspector;
#endif

    
    public interface IEcsComponentConverter : 
        ILeoEcsConverterStatus
#if ODIN_INSPECTOR
        , ISearchFilterable
#endif
    {
        public string Name { get; }
        
        void Apply(ProtoWorld world, int entity);
    }
}