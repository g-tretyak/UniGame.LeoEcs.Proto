namespace UniGame.LeoEcs.Shared.Extensions
{
    using System.Collections.Generic;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.Core.Runtime;
    using Abstract;
    using UnityEngine;

    public static class EntityExtensions
    {
        private static List<IInitializeWithEntityData> InitializableComponents = new List<IInitializeWithEntityData>();

        public static ILifeTime DestroyEntityWith(this ILifeTime lifeTime, int entity, ProtoWorld world)
        {
            if (entity < 0) return lifeTime;
            return lifeTime.DestroyEntityWith((ProtoEntity)entity, world);
        }
        
        public static ILifeTime DestroyEntityWith(this ILifeTime lifeTime, ProtoEntity entity, ProtoWorld world)
        {
            if (world.IsAlive() == false) return lifeTime;
            
            lifeTime.AddCleanUpAction(() =>
            {
                if (!world.IsAlive()) return;
                
                var packedEntity = world.PackEntity(entity);
                if (!packedEntity.Unpack(world, out var unpacked)) return;
                
                world.DelEntity(entity);
            });
            
            return lifeTime;
        }

        public static Object InitializeWithEcsData(this Object target, ProtoWorld world, int entity)
        {
            switch (target)
            {
                case IInitializeWithEntityData initializable:
                    initializable.InitializeEcsData(world, entity);
                    break;
                case GameObject gameObject:
                {
                    InitializableComponents.Clear();
                    gameObject.GetComponents(InitializableComponents);

                    foreach (var initializableComponent in InitializableComponents)
                        initializableComponent.InitializeEcsData(world, entity);

                    InitializableComponents.Clear();
                    
                    
                    
                    break;
                }
            }

            return target;
        }
    }
}