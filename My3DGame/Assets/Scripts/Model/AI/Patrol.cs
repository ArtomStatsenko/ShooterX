using UnityEngine;
using UnityEngine.AI;


namespace StatsenkoAA
{
    public static class Patrol
    {
        public static Vector3 GenericPoint(Transform agent)
        {
            Vector3 result;

            var distance = Random.Range(5, 50);
            var randomPoint = Random.insideUnitSphere * distance;

            NavMesh.SamplePosition(agent.position + randomPoint,
                out var hit, distance, NavMesh.AllAreas);
            result = hit.position;

            return result;
        }
    }
}
