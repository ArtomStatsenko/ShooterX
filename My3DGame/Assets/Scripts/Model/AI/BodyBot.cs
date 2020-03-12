using System;


namespace StatsenkoAA
{
    public sealed class BodyBot : BaseObjectScene, ISetDamage
    {
        public event Action<InfoCollision> OnApplyDamageChange;

        public void SetDamage(InfoCollision info)
        {
            OnApplyDamageChange?.Invoke(info);
        }
    }
}
