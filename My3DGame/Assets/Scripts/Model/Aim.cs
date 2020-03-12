using System;
using UnityEngine;


namespace StatsenkoAA
{
    public abstract class Aim : MonoBehaviour, ISetDamage, ISelectObj
    {
        public event Action OnPointChange = delegate {  };
		
        public float Hp = 100;
        public bool _isDead;
        public float _timeToDestroy = 10.0f;

        public virtual void SetDamage(InfoCollision info)
        {
            OnPointChange.Invoke();
        }

        public string GetMessage()
        {
            return gameObject.name;
        }
    }
}
