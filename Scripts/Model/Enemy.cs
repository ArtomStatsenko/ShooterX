using System;
using UnityEngine;


namespace StatsenkoAA
{
    public sealed class Enemy : Aim
    {
        [SerializeField] private float _scaleChanging = 1.1f;
        private Transform _startTransform;

        private void Start()
        {
            _startTransform = gameObject.transform;
        }

        public override void SetDamage(InfoCollision info)
        {
            if (_isDead) return;
            if (Hp > 0)
            {
                Hp -= info.Damage;
                gameObject.transform.localScale *= _scaleChanging;
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
