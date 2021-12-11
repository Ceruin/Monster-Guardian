using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    /// <summary>
    /// Additional methodologies for nav agents such as custom calculations and path checks.
    /// </summary>
    public static class NavAgentExtensions
    {
        /// <summary>
        /// Sets the nav agent on a path if it exists
        /// </summary>
        /// <param name="agent"></param>
        /// <param name="goal"></param>
        public static void Path(this NavMeshAgent agent, Vector3? goal)
        {
            if (goal.HasValue)
            {
                agent.SetDestination(goal.Value);
                var path = new NavMeshPath();
                NavMesh.CalculatePath(agent.gameObject.transform.position, goal.Value, NavMesh.AllAreas, path);
                agent.SetPath(path);
            }
            else
            {
                agent.ResetPath();
            }
        }

        /// <summary>
        /// Sets a randomized path
        /// </summary>
        /// <param name="agent"></param>
        /// <param name="center"></param>
        /// <param name="range"></param>
        public static void PathRandom(this NavMeshAgent agent, Vector3 center, float range)
        {
            agent.Path(NavMeshController.RandomPoint(center, range));
        }
    }
}