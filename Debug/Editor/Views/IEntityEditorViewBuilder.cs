namespace UniGame.LeoEcs.Debug.Editor
{
    using System.Collections.Generic;
    using Leopotam.EcsProto;

    public interface IEntityEditorViewBuilder
    {
        void Initialize(ProtoWorld world);
        
        void Execute(List<EntityEditorView> views);

        void Execute(EntityEditorView view);
    }
}