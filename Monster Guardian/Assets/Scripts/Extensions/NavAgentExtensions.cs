using UnityEngine;
using UnityEngine.AI;

public static class NavAgentExtensions
{
    public static void Path(this NavMeshAgent agent, Vector3 goal)
    {
        agent.destination = goal;
    }

    public static void PathRandom(this NavMeshAgent agent, Vector3 center, float range)
    {
        agent.Path(NavMeshController.RandomPoint(center, range));
    }
}