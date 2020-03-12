using System;
using UnityEngine;


namespace StatsenkoAA
{
    public sealed class CubeAim : Aim
    {
        public override void SetDamage(InfoCollision info)
        {
            if (_isDead) return;
            if (Hp > 0)
            {
                Hp -= info.Damage;
            }         

            if (Hp <= 0)
            {
                base.SetDamage(info);
                if (!TryGetComponent<Rigidbody>(out _))
                {
                    gameObject.AddComponent<Rigidbody>();
                }
                Destroy(gameObject, _timeToDestroy);
                _isDead = true;
            }        
        }
    }
}
