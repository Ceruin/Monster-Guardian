using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Feeling : MonoBehaviour
    {
        public FeelStatus Status { get; }
    }
}