using UnityEngine;


namespace StatsenkoAA
{
    public sealed class Mine : PickupObject
    {
        [SerializeField] private float _curDamage = 50;
        [SerializeField] private float _timeToExplosion = 0;
        [SerializeField] private GameObject _smoke;

        public override void OnCollisionEnter(Collision collision)
        {
            var tempObj = collision.gameObject.GetComponent<ISetDamage>();
            
            if (tempObj != null)
            {
                tempObj.SetDamage(new InfoCollision(_curDamage, collision.contacts[0], collision.transform,
                Rigidbody.velocity));
                Invoke(nameof(Detonate), _timeToExplosion);
                Destroy(gameObject, _timeToDestruct);
            }
        }

        private void Detonate(GameObject tempObj)
        {
            Instantiate(_smoke, transform);
        }
    }
}
