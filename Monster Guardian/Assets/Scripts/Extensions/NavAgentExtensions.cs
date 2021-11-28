using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    public static class NavAgentExtensions
    {
        public static void Path(this NavMeshAgent agent, Vector3? goal)
        {
            if (goal.HasValue)
            {
                //agent.SetDestination(goal.Value);
                var path = new NavMeshPath();
                NavMesh.CalculatePath(agent.gameObject.transform.position, goal.Value, NavMesh.AllAreas, path);
                agent.SetPath(path);
            }
            else 
            {
                agent.ResetPath();
            }
        }

        public static void PathRandom(this NavMeshAgent agent, Vector3 center, float range)
        {
            agent.Path(NavMeshController.RandomPoint(center, range));
        }
    }
}