using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class CameraUtils
{
    public static Vector2 ConvertToScreen(this Camera main, Vector3 pos)
    {
        Vector2 space = main.WorldToScreenPoint(pos);
        space.y = Screen.height - space.y; // unity is horrible and doesn't do this for you >:(
        return space;
    }
}
