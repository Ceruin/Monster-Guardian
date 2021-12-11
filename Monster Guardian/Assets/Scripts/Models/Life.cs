using System;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// This is a component that allows a game object to be defined as having health and supplies methods to destroy itself on “death”
    /// </summary>
    [Serializable]
    public class Life : MonoBehaviour
    {
        public int HealthPoints;

        public TimeSpan TimeToLive;

        private Stopwatch LifeTimer = new Stopwatch();

        public GameObject ExplodeEffect;

        public bool Dead
        {
            get
            {
                return !LifeTimer.IsRunning || LifeTimer.Elapsed >= TimeToLive || HealthPoints <= 0;
            }
        }

        public void Start()
        {
            LifeTimer.Start();
        }

        /// <summary>
        /// Stop the life timer
        /// </summary>
        public void Stop()
        {
            LifeTimer.Stop();
        }

        /// <summary>
        /// Commit death to the game object
        /// </summary>
        public void Death()
        {
            Instantiate(ExplodeEffect, transform.position + transform.up * 1.5f, Quaternion.identity);
            Destroy(this);
        }

        /// <summary>
        /// Heal the stats by increasing them
        /// </summary>
        /// <param name="health"></param>
        public void Heal(int health)
        {
            HealthPoints += health;
        }

        /// <summary>
        /// Take damage by decrasing life stats
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(int damage)
        {
            HealthPoints -= damage;
        }
    }
}