using System;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// This is a component to add additional selection capabilities to a game object such as highlighting
    /// </summary>
    [Serializable]
    public class Selection : MonoBehaviour
    {
        public bool Selected { get; set; } = false;

        /// <summary>
        /// Deselect set
        /// </summary>
        public void DeSelect()
        {
            Selected = false;
        }

        /// <summary>
        /// Select set
        /// </summary>
        public void Select()
        {
            Selected = true;
        }
    }
}