using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Selection : MonoBehaviour
    {
        public bool Selected { get; set; } = false;

        public void DeSelect()
        {
            Selected = false;
        }

        public void Select()
        {
            Selected = true;
        }
    }
}