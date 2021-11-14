using System;
using UnityEngine;

[Serializable]
public class Selection
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