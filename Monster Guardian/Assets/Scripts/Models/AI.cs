using System;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class AI : MonoBehaviour
{
    public NavMeshAgent Agent;
    public MovementType movementType;
    public Transform Player;

    public float SearchRadius = 10.0f;
    public GameObject Target;

    /// <summary>
    /// Assign and cause an action to the AI for it's target
    /// </summary>
    public void AssignTarget()
    {
    }

    public void Awake()
    {
        Agent = this.GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// Set the AI into an Idle state
    /// </summary>
    /// <param name="currentPosition"></param>
    /// <param name="radius"></param>
    public void Idle(Vector3 currentPosition, float radius)
    {
        if (Agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            Agent.PathRandom(currentPosition, radius);
        }
    }

    /// <summary>
    /// Search the surrounding area and provide all objects found
    /// </summary>
    public void SearchArea()
    {
    }
}