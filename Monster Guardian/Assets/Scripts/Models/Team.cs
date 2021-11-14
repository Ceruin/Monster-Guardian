using System;
using UnityEngine;

[Serializable]
public class Team : MonoBehaviour
{
    private TeamStatus Status { get; set; }

    private void Start()
    {
        TeamStatus _status;
        Enum.TryParse(this.tag, out _status);
        Status = _status;
    }
}