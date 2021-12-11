using System;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// This is a component to help determine the mood of the game object pertaining to it’s situation
    /// </summary>
    [Serializable]
    public class Feeling : MonoBehaviour
    {
        public FeelStatus Status { get; }
    }
}