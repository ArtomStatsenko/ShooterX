using UnityEngine;


namespace StatsenkoAA
{
    public abstract class PickupObject : BaseObjectScene
    {
        public float _timeToDestruct = 0;

        public abstract void OnCollisionEnter(Collision collision);
    }
}
