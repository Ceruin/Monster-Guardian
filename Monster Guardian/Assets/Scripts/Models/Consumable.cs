using System;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// This is a consumable component class that marks a game object as consumable
    /// these values are fed into various systems
    /// </summary>
    [Serializable]
    public class Consumable : MonoBehaviour
    {
        public int HungerValue { get; set; } // Amount Hunger
        public int LifeValue { get; set; }  // Amount Life
    }
}