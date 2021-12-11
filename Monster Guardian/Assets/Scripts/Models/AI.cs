using System;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    /// <summary>
    /// This is a component class used to add additional functionality to the Unity Agent class
    /// </summary>
    [Serializable]
    public class AI : MonoBehaviour
    {
        private NavMeshAgent Agent;

        [SerializeField]
        private float SearchRadius = 10.0f;

        public void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
        }

        /// <summary>
        /// Gets the current destination of the AI agent
        /// </summary>
        /// <returns></returns>
        public Vector3 GetDestination()
        {
            return Agent.destination;
        }

        /// <summary>
        /// Gets the current path status
        /// </summary>
        /// <returns></returns>
        public NavMeshPathStatus GetStatus()
        {
            // Check if we've reached the destination
            if (!Agent.pathPending)
            {
                if (Agent.remainingDistance <= Agent.stoppingDistance)
                {
                    if (!Agent.hasPath || Agent.velocity.sqrMagnitude == 0f)
                    {
                        return NavMeshPathStatus.PathComplete;
                    }
                }
            }
            return NavMeshPathStatus.PathPartial;
        }

        /// <summary>
        /// Set the AI into an Idle state
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="radius"></param>
        public void Idle()
        {
            // set pathing to random
            if (GetStatus() == NavMeshPathStatus.PathComplete)
            {
                Agent.PathRandom(transform.position, SearchRadius);
            }
        }

        /// <summary>
        /// Search within the ai's range for a specific gameobject
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public bool InsideSearchArea(GameObject enemy)
        {
            return Vector3.Distance(enemy.transform.position, this.transform.position) <= SearchRadius;
        }

        /// <summary>
        /// Move to a location
        /// </summary>
        /// <param name="location"></param>
        public void Move(Vector3? location)
        {
            Agent.Path(location);
        }

        /// <summary>
        /// Move to an enemies position
        /// </summary>
        /// <param name="enemy"></param>
        public void Move(GameObject enemy)
        {
            Agent.Path(enemy.transform.position);
        }

        /// <summary>
        /// Search the surrounding area and provide all objects found
        /// </summary>
        public void SearchArea()
        {
        }
    }
}