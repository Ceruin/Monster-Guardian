using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Traits : MonoBehaviour
    {
        public int Age;
        public string Color;
        public int EvoLevel;
        public int PowerLevel;

        public void Generate()
        {
            // generate basic traits
            // generate randomized traits
        }
    }
}