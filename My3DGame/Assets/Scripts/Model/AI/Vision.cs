using UnityEngine;


namespace StatsenkoAA
{
    [System.Serializable]
    public sealed class Vision
    {
        public float ActiveDistance = 10;
        public float ActiveAngle = 35;

        public bool VisionM(Transform player, Transform target)
        {
            return Distance(player, target) && Angle(player, target) && !CheckBloked(player, target);
        }

        private bool CheckBloked(Transform player, Transform target)
        {
            if (!Physics.Linecast(player.position, target.position, out var hit)) return true;
            return hit.transform != target;
        }

        private bool Angle(Transform player, Transform target)
        {
            var angle = Vector3.Angle(player.forward, target.position - player.position);
            return angle <= ActiveAngle;
        }

        private bool Distance(Transform player, Transform target)
        {
            var distance = Vector3.Distance(player.position, target.position); //todo оптимизация
            return distance <= ActiveDistance;
        }
    }
}
