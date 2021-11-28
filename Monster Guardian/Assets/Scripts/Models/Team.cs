using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Team : MonoBehaviour
    {
        private TeamStatus Status { get; set; }

        private void Start()
        {
            TeamStatus _status;
            Enum.TryParse(tag, out _status);
            Status = _status;
        }
    }
}