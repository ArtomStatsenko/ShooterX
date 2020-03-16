using System;


namespace StatsenkoAA
{
    public sealed class BodyBot : BaseObjectScene, ISetDamage, ICanHeal
    {
        public event Action<InfoCollision> OnApplyDamageChange;
        public event Action<InfoCollision> OnApplyHealChange;

        public void SetDamage(InfoCollision info)
        {
            OnApplyDamageChange?.Invoke(info);
        }

        public void Heal(InfoCollision info)
        {
            OnApplyHealChange?.Invoke(info);
        }
    }
}
