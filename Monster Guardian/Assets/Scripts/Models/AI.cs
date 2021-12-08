using System;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
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

        public Vector3 GetDestination()
        {
            return Agent.destination;
        }

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

        public bool InsideSearchArea(GameObject enemy)
        {
            return Vector3.Distance(enemy.transform.position, this.transform.position) <= SearchRadius;
        }

        public void Move(Vector3? location)
        {
            Agent.Path(location);
        }

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