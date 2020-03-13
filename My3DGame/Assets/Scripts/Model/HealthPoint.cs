using UnityEngine;


namespace StatsenkoAA
{
    public sealed class HealthPoint : PickupObject
    {
        [SerializeField] private float _curHealth = 50;
        [SerializeField] private GameObject _light;

        protected override void Awake()
        {
            base.Awake();
            Instantiate(_light, gameObject.transform);
        }

        public override void OnCollisionEnter(Collision collision)
        {
            var tempObj = collision.gameObject.GetComponent<ICanHeal>();

            if (tempObj != null)
            {
                tempObj.Heal(new InfoCollision(_curHealth, collision.contacts[0], collision.transform,
                Rigidbody.velocity));
                Destroy(gameObject, _timeToDestruct);
            }
        }
    }
}
