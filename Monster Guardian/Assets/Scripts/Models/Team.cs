using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Team : MonoBehaviour
    {
        public TeamStatus Status { get; private set; }

        private void Awake()
        {
            SetTeam();
        }

        public void SetTeam()
        {
            TeamStatus _status;
            Enum.TryParse(tag, out _status);
            Status = _status;
        }
    }
}