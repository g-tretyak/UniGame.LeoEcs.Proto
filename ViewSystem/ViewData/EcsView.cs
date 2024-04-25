namespace UniGame.LeoEcs.ViewSystem.Converters
{
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.UiSystem.Runtime;
    using UnityEngine;
    
    [RequireComponent(typeof(LeoEcsMonoConverter))]
    [RequireComponent(typeof(EcsViewConverter))]
    public class EcsView : ViewBase, IEcsView
    {
        
    }
}
