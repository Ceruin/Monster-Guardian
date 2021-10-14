using System;
using UnityEngine;
using UnityEngine.AI;

public class PathingController : MonoBehaviour
{
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToLocation(Vector3 goal)
    {
        agent.destination = goal;
    }
}