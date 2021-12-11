using System;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// This is a component to create traits specific to that game objects creature representation
    /// </summary>
    [Serializable]
    public class Traits : MonoBehaviour
    {
        public int Age;
        public string Color;
        public int EvoLevel;
        public int PowerLevel;

        /// <summary>
        /// Generate basic and randomized traits
        /// </summary>
        public void Generate()
        {
            // generate basic traits
            // generate randomized traits
        }
    }
}