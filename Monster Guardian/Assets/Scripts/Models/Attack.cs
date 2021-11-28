using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Attack : MonoBehaviour
    {
        public float AttackRadius = 0.0f;

        private int Damage = 5; // damage

        public int GetDamage()
        {
            return Damage;
        }

        /// <summary>
        /// Reduce my health
        /// </summary>
        public void GetHit()
        {
            // inflict ailment
        }

        /// <summary>
        /// Reduce enemy health
        /// </summary>
        public void Hit()
        {
            // trigger enemy gethit
        }

        /// <summary>
        /// Check if target is within radius
        /// </summary>
        private void CanHit()
        {
            // check if the target is in radius
        }
    }
}