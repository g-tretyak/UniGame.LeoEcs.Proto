namespace UniGame.LeoEcs.Shared.Extensions
{
    using System.Runtime.CompilerServices;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;

    public static class EcsFilterExtensions
    {
        public static readonly ProtoEntity InvalidEntity = ProtoEntity.FromIdx(-1); 
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int First(this EcsFilter filter)
        {
            foreach (var entity in filter)
                return (int)entity;

            return -1;
        }
    }
}