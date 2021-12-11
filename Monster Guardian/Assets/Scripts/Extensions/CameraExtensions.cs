using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Camera extensions such as calculating camera positions on 2D and 3D planes.
    /// </summary>
    public static class CameraExtensions
    {
        /// <summary>
        /// Converts a world position to screen postion
        /// </summary>
        /// <param name="main"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static Vector2 ConvertToScreen(this Camera main, Vector3 pos)
        {
            Vector2 space = main.WorldToScreenPoint(pos);
            space.y = Screen.height - space.y; // unity is horrible and doesn't do this for you >:(
            return space;
        }

        /// <summary>
        /// Converts a screen position to a world position if it exists
        /// </summary>
        /// <param name="main"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static Vector3 GetWorldPOS(this Camera main, Vector3 pos)
        {
            Ray ray = main.ScreenPointToRay(pos);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            return hit.point;
        }
    }
}