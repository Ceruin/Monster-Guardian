using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToLocation(new Vector3(0, 0,0));
    }

    private void MoveToLocation(Vector3 goal)
    {
        agent.destination = goal;
    }
}
