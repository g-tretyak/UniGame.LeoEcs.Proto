namespace UniGame.LeoEcs.Bootstrap.Runtime.PostInitialize
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Leopotam.EcsProto;
    using Shared.Extensions;
    using UniModules.UniCore.Runtime.ReflectionUtils;
    using UniModules.UniCore.Runtime.Utils;

    [Serializable]
    public class EcsDiAspectInjection : IEcsDiInjection
    {
        private Dictionary<Type,object> _aspects = new();
        private Type _aspectType = typeof(IProtoAspect);
        private string _initializeMethodName = nameof(IProtoAspect.Init);
        private MethodInfo _initializeMethod;
        private object[] _parameters = new[] { (object)0 };
        
        public void ApplyInjection(
            IProtoSystems ecsSystems, 
            FieldInfo field, 
            object target, 
            IReadOnlyList<IEcsDiInjection> injections)
        {
            var fieldType = field.FieldType;
            if (!_aspectType.IsAssignableFrom(fieldType)) return;

            var aspectValue = field.GetValue(target);
            if (aspectValue != null) return;

            if (_aspects.TryGetValue(fieldType, out var value))
            {
                field.SetValue(target,value);
                return;
            }

            value = fieldType.CreateWithDefaultConstructor();

            _parameters[0] = ecsSystems.GetWorld();
            _aspects.Add(fieldType, value);
            _initializeMethod ??= _aspectType.GetMethod(_initializeMethodName);
            _initializeMethod?.Invoke(value, _parameters);

            var fields = fieldType.GetInstanceFields();
            foreach (var fieldInfo in fields)
            {
                foreach (var diInjection in injections)
                    diInjection.ApplyInjection(ecsSystems, fieldInfo, value, injections);
            }
            
            field.SetValue(target,value);
        }
    }
}