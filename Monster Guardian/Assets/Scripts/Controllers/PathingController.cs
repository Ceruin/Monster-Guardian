using System;
using UnityEngine;
using UnityEngine.AI;

public class PathingController : MonoBehaviour
{
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //MoveToLocation(new Vector3(0, 0, 0)); // todo: remove, used for basic testing
    }

    public void MoveToLocation(Vector3 goal)
    {
        agent.destination = goal;
    }
}