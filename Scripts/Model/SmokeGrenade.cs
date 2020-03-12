using UnityEngine;


namespace StatsenkoAA
{
    public sealed class SmokeGrenade : Ammunition
    {
        [SerializeField] private float _timeToExplosion = 2.0f;
        [SerializeField] private GameObject _smoke;

        private float _timeToDestroy = 10.0f;       

        private void Start()
        {
            DestroyAmmunition(_timeToDestroy);
            Invoke(nameof(Detonate), _timeToExplosion);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var setDamage = collision.gameObject.GetComponent<ISetDamage>();

            if (setDamage != null)
            {
                setDamage.SetDamage(new InfoCollision(_curDamage, collision.contacts[0], collision.transform, Rigidbody.velocity));
            }
        }

        private void Detonate()
        {
            Instantiate(_smoke, transform);
        }
    }
}
