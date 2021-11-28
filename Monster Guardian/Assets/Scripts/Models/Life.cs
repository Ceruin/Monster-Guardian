using System;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Scripts
{
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

        public void Stop()
        {
            LifeTimer.Stop();
        }

        public void Death()
        {
            Instantiate(ExplodeEffect, transform.position + transform.up * 1.5f, Quaternion.identity);
            Destroy(this);
        }

        public void Heal(int health)
        {
            HealthPoints += health;
        }

        public void TakeDamage(int damage)
        {
            HealthPoints -= damage;
        }
    }
}