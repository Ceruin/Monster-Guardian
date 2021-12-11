using System;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// This is a component that helps a game object to determine its team in relation to the player
    /// </summary>
    [Serializable]
    public class Team : MonoBehaviour
    {
        public TeamStatus Status { get; private set; }

        private void Awake()
        {
            SetTeam();
        }

        /// <summary>
        /// Set the team status
        /// </summary>
        public void SetTeam()
        {
            TeamStatus _status;
            Enum.TryParse(tag, out _status);
            Status = _status;
        }
    }
}