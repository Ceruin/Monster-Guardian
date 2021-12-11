using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Game Object extension methods.
    /// </summary>
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Checks if the gameobject has a value or is null
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public static bool HasValue(this GameObject gameObject)
        {
            return gameObject != null;
        }
    }
}