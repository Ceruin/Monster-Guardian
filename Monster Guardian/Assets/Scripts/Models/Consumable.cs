using System;
using UnityEngine;

namespace Assets.Scripts
{

    /// <summary>
    /// Represents a consumable object, these values are fed into various systems
    /// </summary>
    [Serializable]
    public class Consumable : MonoBehaviour
    {
        public int HungerValue { get; set; } // Amount Hunger
        public int LifeValue { get; set; }  // Amount Life
    }
}