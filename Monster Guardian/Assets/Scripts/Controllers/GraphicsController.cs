using UnityEngine;

public static class GraphicsController
{
    public static void DrawRect()
    {
        new RectTransform();
    }

    public static void DrawScreenRect(Rect rect, Color color)
    {
        GUI.color = color;
        GUI.DrawTexture(rect, WhiteTexture());
        GUI.color = Color.white;
    }

    public static void DrawScreenRectBorder(Rect rect, float thickness, Color color)
    {
        DrawScreenRect(new Rect(rect.xMin, rect.yMin, rect.width, thickness), color); // Top
        DrawScreenRect(new Rect(rect.xMin, rect.yMin, thickness, rect.height), color); // Left
        DrawScreenRect(new Rect(rect.xMax - thickness, rect.yMin, thickness, rect.height), color); // Right
        DrawScreenRect(new Rect(rect.xMin, rect.yMax - thickness, rect.width, thickness), color);  // Bottom
    }

    public static Rect GetScreenRect(Vector3 screenPosition1, Vector3 screenPosition2)
    {
        // Move origin from bottom left to top left
        screenPosition1.y = Screen.height - screenPosition1.y;
        screenPosition2.y = Screen.height - screenPosition2.y;
        // Calculate corners
        var topLeft = Vector3.Min(screenPosition1, screenPosition2);
        var bottomRight = Vector3.Max(screenPosition1, screenPosition2);
        // Create Rect
        return Rect.MinMaxRect(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y);
    }

    public static Texture2D WhiteTexture()
    {
        Texture2D texture;
        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, Color.white);
        texture.Apply();
        return texture;
    }
}