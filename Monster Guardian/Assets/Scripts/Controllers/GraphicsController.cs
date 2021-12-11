using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// This contains methods for using the System.Drawing to create various graphics such as the square selection box.
    /// </summary>
    public static class GraphicsController
    {
        /// <summary>
        /// Draws a rectangle on the current screen using two vector points
        /// Colors the screen rectangle in
        /// </summary>
        /// <param name="screenPosition1"></param>
        /// <param name="screenPosition2"></param>
        /// <returns></returns>
        public static Rect DrawRectangle(Vector3 screenPosition1, Vector3 screenPosition2)
        {
            Rect drawnRect = GetScreenRect(screenPosition1, screenPosition2);
            drawnRect.DrawScreen(new Color(0.8f, 0.8f, 0.95f, 0.25f));
            drawnRect.DrawBorder(2, new Color(0.8f, 0.8f, 0.95f));
            return drawnRect;
        }

        /// <summary>
        /// Gets a rectangle object from two vector points
        /// </summary>
        /// <param name="screenPosition1"></param>
        /// <param name="screenPosition2"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates a white texture
        /// </summary>
        /// <returns></returns>
        public static Texture2D WhiteTexture()
        {
            Texture2D texture;
            texture = new Texture2D(1, 1);
            texture.SetPixel(0, 0, Color.white);
            texture.Apply();
            return texture;
        }
    }
}