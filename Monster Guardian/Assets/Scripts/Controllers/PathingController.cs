using UnityEngine;
using UnityEngine.AI;

public class PathingController : MonoBehaviour
{
    private NavMeshAgent agent;

    public void MoveToLocation(Vector3 goal)
    {
        agent.destination = goal;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
}