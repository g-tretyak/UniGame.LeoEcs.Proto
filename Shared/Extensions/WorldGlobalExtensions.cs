namespace UniGame.LeoEcs.Shared.Extensions
{
    using System;
    using System.Runtime.CompilerServices;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;
    using UniModules.UniCore.Runtime.Extension;
    using UniModules.UniCore.Runtime.Utils;
    using UniModules.UniGame.Context.Runtime.Context;

    public static class WorldGlobalExtensions
    {
        private static MemorizeItem<ProtoWorld, EntityContext> _globalValues = MemorizeTool
            .Memorize<ProtoWorld, EntityContext>(x =>
            {
                var context = new EntityContext();
                var worldLifeTime = x.GetWorldLifeTime();
                context.AddTo(worldLifeTime);
                return context;
            });

        public static bool HasFlag<T>(this ProtoWorld world, T flag)
            where T  : Enum
        {
            var context = _globalValues[world];
            if(!context.Contains<T>()) return false;
            
            var value = context.Get<T>();
            var isSet = value.IsFlagSet(flag);
            return isSet;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetGlobal<T>(this ProtoWorld world)
        {
            var globals = _globalValues[world];
            var value = globals.Get<T>();
            return value;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T SetGlobal<T>(this IProtoSystems systems,T value)
        {
            var world = systems.World();
            return world.SetGlobal(value);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T SetGlobal<T>(this ProtoWorld world,T value)
        {
            var globals = _globalValues[world];
            globals.Publish(value);
            return value;
        }
    }
}