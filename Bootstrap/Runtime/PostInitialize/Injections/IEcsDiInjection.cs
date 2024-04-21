namespace UniGame.LeoEcs.Bootstrap.Runtime.PostInitialize
{
    using System.Collections.Generic;
    using System.Reflection;
    using Leopotam.EcsLite;
    using Leopotam.EcsProto;

    public interface IEcsDiInjection
    {
        void ApplyInjection(IProtoSystems ecsSystems, FieldInfo field, object target, IReadOnlyList<IEcsDiInjection> injections);
    }
}