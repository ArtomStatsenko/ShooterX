using System;


namespace StatsenkoAA
{
    public sealed class HeadBot : BaseObjectScene, ISetDamage
    {
        public event Action<InfoCollision> OnApplyDamageChange;
        public void SetDamage(InfoCollision info)
        {
            OnApplyDamageChange?.Invoke(new InfoCollision(info.Damage * 500,
                info.Contact, info.ObjectCollision, info.Direction));
        }
    }
}
