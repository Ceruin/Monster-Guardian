using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    /// <summary>
    /// This is a set of navmesh exclusive methods since the navmesh itself is a singleton instance in unity it cannot be an extension so it is under a controller.
    /// </summary>
    public static class NavMeshController
    {
        /// <summary>
        /// Gets a randomized point on the nav mesh
        /// </summary>
        /// <param name="center"></param>
        /// <param name="range"></param>
        /// <param name="hitAttempts"></param>
        /// <returns></returns>
        public static Vector3 RandomPoint(Vector3 center, float range, int hitAttempts = 30)
        {
            for (int i = 0; i < hitAttempts; i++) // retry if failed
            {
                Vector3 randomPoint = center + Random.insideUnitSphere * range;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
                {
                    return hit.position;
                }
            }
            return center; // default if nothing found :/ todo: maybe make it null or throw an error
        }
    }
}