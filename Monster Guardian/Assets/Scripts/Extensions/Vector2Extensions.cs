using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    /// <summary>
    /// Vector2 extension methods to gain specific value information and conversions.
    /// </summary>
    public static class Vector2Extensions
    {
        /// <summary>
        /// Checks if the users pointer is over a UI interface object
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static bool IsPointerOverUIObject(this Vector2 position)
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = position;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].gameObject.layer == 5) // 5 = UI layer
                {
                    return true;
                }
            }

            return false;
        }
    }
}