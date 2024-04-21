namespace UniGame.LeoEcs.Bootstrap.Runtime
{
    using System;
    using System.Runtime.CompilerServices;
    using Abstract;
    using Leopotam.EcsLite;
    using UnityEngine;

    /// <summary>
    /// Leo Ecs Run System With runtime Toggle.
    /// </summary>
    [Serializable]
    public abstract class LeoEcsRunSystem : ILeoEcsSystem, IEcsRunSystem
    {
        /// <summary>
        /// Is ecs system active.
        /// </summary>
        [SerializeField]
        private bool _enabled = true;

        public bool Enabled => _enabled;

        public void Run()
        {
#if UNITY_EDITOR
            if (!_enabled)
                return;
#endif
            RunSystem();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract void RunSystem();

    }
}