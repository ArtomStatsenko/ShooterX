using UnityEngine;


namespace StatsenkoAA
{
    public readonly struct InfoCollision
    {
        private readonly Vector3 _direction;
        private readonly float _damage;
        private readonly ContactPoint _contact;
        private readonly Transform _objectCollision;

        public InfoCollision(float damage, ContactPoint contact, Transform objectCollision, Vector3 direction = default)
        {
            _damage = damage;
            _direction = direction;
            _contact = contact;
            _objectCollision = objectCollision;
        }

        public Vector3 Direction => _direction;

        public float Damage => _damage;

        public ContactPoint Contact => _contact;

        public Transform ObjectCollision => _objectCollision;
    }
}
