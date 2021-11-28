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
        float SearchRadius = 10.0f;


        public void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
        }

        public void Move(Vector3? location)
        {
            Agent.Path(location);
        }

        public void Move(GameObject enemy)
        {
            Agent.Path(enemy.transform.position);
        }

        public bool InsideSearchArea(GameObject enemy)
        {
            return Vector3.Distance(enemy.transform.position, this.transform.position) <= SearchRadius;
        }

        public NavMeshPathStatus GetStatus()
        {
            return Agent.pathStatus;
        }

        public Vector3 GetDestination()
        {
            return Agent.destination;
        }

        /// <summary>
        /// Set the AI into an Idle state
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="radius"></param>
        public void Idle()
        {
            // set pathing to random
            if (Agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                Agent.PathRandom(transform.position, SearchRadius);
            }
        }

        /// <summary>
        /// Search the surrounding area and provide all objects found
        /// </summary>
        public void SearchArea()
        {
        }
    }
}