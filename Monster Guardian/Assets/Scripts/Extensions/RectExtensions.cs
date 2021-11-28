using UnityEngine;

namespace Assets.Scripts
{
    public static class RectExtensions
    {
        public static void DrawBorder(this Rect rect, float thickness, Color color)
        {
            new Rect(rect.xMin, rect.yMin, rect.width, thickness).DrawScreen(color); // Top
            new Rect(rect.xMin, rect.yMin, thickness, rect.height).DrawScreen(color); // Left
            new Rect(rect.xMax - thickness, rect.yMin, thickness, rect.height).DrawScreen(color); // Right
            new Rect(rect.xMin, rect.yMax - thickness, rect.width, thickness).DrawScreen(color);  // Bottom
        }

        /// <summary>
        /// todo: convert this to any color
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="color"></param>
        public static void DrawScreen(this Rect rect, Color color)
        {
            GUI.color = color;
            GUI.DrawTexture(rect, GraphicsController.WhiteTexture());
            GUI.color = Color.white;
        }
    }
}