namespace UniGame.LeoEcs.Bootstrap.Runtime.Abstract
{
    public enum EcsPlayerUpdateType : byte
    {
        None,
        Update,
        FixedUpdate,
        LateUpdate,
        Gizmos,
    }
}