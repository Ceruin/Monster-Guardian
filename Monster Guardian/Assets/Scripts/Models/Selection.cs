using System;
using UnityEngine;

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

    /// <summary>
    /// Set our active target
    /// This could be an enemy, a station, a resource or more
    /// </summary>
    /// <param name="aI"></param>
    public void SetTarget(AI aI)
    {
    }
}