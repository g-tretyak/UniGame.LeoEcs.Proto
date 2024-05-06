namespace UniGame.LeoEcs.Shared.Abstract
{
    public interface IApplyableComponent <TComponent>
        where TComponent : struct
    {
        /// <summary>
        /// Apply component data to parameter target
        /// </summary>
        /// <param name="component"></param>
        void Apply(ref TComponent component);
    }
}
