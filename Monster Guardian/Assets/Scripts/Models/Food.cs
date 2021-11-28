﻿using UnityEngine;

namespace Assets.Scripts
{

    /// <summary>
    /// Class representation of a pet item
    /// </summary>
    public class Food : MonoBehaviour
    {
        [SerializeField]
        public Life Life;

        private Consumable Consumable;
    }
}