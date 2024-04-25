namespace UniGame.LeoEcs.ViewSystem.Behavriour
{
    using System;
    using Core.Runtime;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsProto;
    using Leopotam.EcsProto.QoL;
    using UniGame.ViewSystem.Runtime;

    public interface IEcsViewTools : ILifeTimeContext
    {
        UniTask AddModelComponentAsync(
            ProtoWorld world,ProtoPackedEntity packedEntity,
            IView view,Type viewType);

        void AddViewModelData(ProtoWorld world,ref ProtoPackedEntity packedEntity,IViewModel model);
    }
}